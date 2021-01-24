    public class PlayMusik : MonoBehaviour
    {
        private static PlayMusik Singleton;
        // Here you reference the secenes where music should be playing
        public List<Scene> scenesWithMusik;
        // Flag to control of music is playing
        private bool isPlayingMusik;
        private void Awake ()
        {
            if(Singleton)
            {
                Debug.Log("Already another PlayMusik in Scene.);
                Destroy(gameObject);
                return;
            }
            Singleton = this;
            DontDestroyOnLoad(gameObject);
            // Make sure listener is only added once
            SceneManager.sceneLoaded -= OnSceneLoaded;
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        private void OnDestroy ()
        {
            // Cleanup listener
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
        // Called when a scene is loaded
        void OnSceneLoaded(Scene scene, LoadSceneMode mode)
        {
            Debug.Log("OnSceneLoaded: " + scene.name);
            Debug.Log(mode);
            // here you handle what should happen with the music e.g.
            // if the loaded scene is in scenesWithMusic enable music
            // (What should happen if you load a scene additive is up to you)
            if(scenesWithMusik.Contains(scene))
            {
                if(!isPlayingMusik)
                {
                    //Todo: Enable Music here!
                    isPlayingMusik = true;
                }
            }
            else
            {
                if(isPlayingMusik)
                {
                    //Todo: Stop Music here!
                    isPlayingMusik = false;
                }  
            }
        }
    }
