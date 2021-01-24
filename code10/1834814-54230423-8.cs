    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/MainCamera", 
    order = 1)]
    public class MainCamera : ScriptableObject
    {
        public List<SceneCameraPair> SceneCameraPairs = new List<SceneCameraPair>();
        public Dictionary<string, Camera> sceneToCamera = new Dictionary<string, Camera>();
        public void AddPair(SceneCameraPair pair)
        {
            if(SceneCameraPairs.Contains(pair)) return;
            SceneCameraPairs.Add(pair);
            sceneToCamera[pair.scene.path] = pair.camera;
        }
        public void ResetPairs()
        {
            SceneCameraPairs.Clear();
            sceneToCamera.Clear();
        }
    }
    [System.Serializable]
    public class SceneCameraPair
    {
        public Scene scene;
        public Camera camera;
    }
