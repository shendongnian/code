    using System;
    #if UNITY_EDITOR // Note that without this pre-processors any build will fail
    using UnityEditor;
    #endif
    using UnityEngine;
    
    // ExecuteInEditMode makes this component also execute if not in PlayMode
    [ExecuteInEditMode]
    public class LoadTimeTracker : MonoBehaviour
    {
        // public only for debugging
        public long playButtonTime;
        public long startTime;
    
    #if UNITY_EDITOR
    
        private void OnPlayModeChanged(PlayModeStateChange stateChange)
        {
            switch (stateChange)
            {
                case PlayModeStateChange.ExitingEditMode:
                    // save the system time when leaving the edit mode
                    playButtonTime = DateTime.Now.Ticks;
                    break;
    
                case PlayModeStateChange.EnteredPlayMode:
                    // save and compare the system time when entering play mode
                    startTime = DateTime.Now.Ticks;
                    var difference = (startTime - playButtonTime) / TimeSpan.TicksPerMillisecond;
    
                    Debug.Log("Load Time was: " + difference + "ms", this);
                    break;
            }
        }
    
        private void OnEnable()
        {
            // Register to the playModestaeChanged event
            EditorApplication.playModeStateChanged += OnPlayModeChanged;
        }
    
        private void OnDisable()
        {
            // Unregister from the playModeStateChanged event
            EditorApplication.playModeStateChanged -= OnPlayModeChanged;
        }
    
    #endif
    }
