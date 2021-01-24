    using UnityEditor;
    
    [InitializeOnLoadAttribute]
    public static class SceneSwitcher
    {
        static SceneSwitcher()
        {
            EditorApplication.playModeStateChanged += LogPlayModeState;
        }
    
        private static void LogPlayModeState(PlayModeStateChange state)
        {
            if (state == PlayModeStateChange.EnteredPlayMode)
                SwitchToSceneView();
        }
    
        static void SwitchToSceneView()
        {
            EditorWindow.FocusWindowIfItsOpen<SceneView>();
    
            /////OR
            //SceneView sceneView = EditorWindow.GetWindow<SceneView>(); ;
            //Type type = sceneView.GetType();
            //EditorWindow.FocusWindowIfItsOpen(type);
        }
    }
