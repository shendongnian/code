    public class RunCodeOnce : MonoBehaviour
    {
        public static RunCodeOnce Instance;
    
        void Awake()
        {
            if (Instance!=null) { Destroy(gameObject); return; } // stops dups running
            DontDestroyOnLoad(gameObject); // keep me forever
            Instance = this; // set the reference to it
    
            ... code to run only once ...
        }
    }
