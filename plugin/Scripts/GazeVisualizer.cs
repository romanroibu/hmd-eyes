﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PupilLabs
{
    public class GazeVisualizer : MonoBehaviour
    {
        public SubscriptionsController subscriptionsController;
        public CalibrationController calibrationController;
        // public bool showGazeBeforeCalibration = false; //TODO

        [Range(0f, 0.99f)]
        public float confidenceThreshold = 0.6f;

        GazeListener gazeListener = null;


        void OnEnable()
        {
            if (gazeListener == null)
            {
                gazeListener = new GazeListener(subscriptionsController);
            }

            if (calibrationController != null)
            {
                calibrationController.OnCalibrationSucceeded += StartVisualizing;
            }
        }

        void OnDisable()
        {
            StopVisualizing();
        }

        void StartVisualizing()
        {
            Debug.Log("Start Visualizing Gaze");
            gazeListener.OnReceive2dGazeTarget += Update2d;
            gazeListener.OnReceive3dGazeTarget += Update3d;
        }

        void StopVisualizing()
        {

        }

        void Update2d(string id, Vector3 pos, float confidence)
        {
            Debug.Log($"GV::Update2d {id} {pos} {confidence}");
        }

        void Update3d(Vector3 pos, float confidence)
        {
            Debug.Log($"GV::Update3d {pos} {confidence}");
        }
    }
}
