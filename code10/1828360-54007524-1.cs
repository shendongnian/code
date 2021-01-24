    using UnityEngine;
    public abstract class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance;
        private static object _lock = new object();
    
        public static T Instance
        {
            get
            {
                if (applicationIsQuitting)
                {
                    Debug.LogWarning("[Singleton] Instance '" + typeof(T) +
                        "' already destroyed on application quit." +
                        " Won't create again - returning null.");
                    return null;
                }
    
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        var instances = FindObjectsOfType<T>();
                        if (instances.Length > 1)
                        {
                            Debug.LogError("[Singleton] Something went really wrong " +
                                ", there are too many Singletons; deleting them: ");
                            for (int i = 1; i < instances.Length; i++)
                            {
                                Debug.LogError("Deleting " + instances[i].gameObject.name);
                                Destroy(instances[i].gameObject);
                            }
                            _instance = FindObjectOfType<T>();
                            return _instance;
                        }
    
                        if (instances.Length > 0)
                            _instance = instances[0];
    
                        if (_instance == null)
                        {
                            GameObject singleton = new GameObject();
                            _instance = singleton.AddComponent<T>();
                            singleton.name = "[Singleton] " + typeof(T).ToString();
    
                            DontDestroyOnLoad(singleton);
    
                            Debug.Log("[Singleton] An instance of " + typeof(T) +
                                " is needed in the scene, so '" + singleton +
                                "' was created with DontDestroyOnLoad.");
                        }
                    }
    
                    return _instance;
                }
            }
        }
    
        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }
    
        /// <summary>
        /// When Unity quits, it destroys objects in a random order.
        /// In principle, a Singleton is only destroyed when application quits.
        /// If any script calls Instance after it have been destroyed, 
        ///   it will create a buggy ghost object that will stay on the Editor scene
        ///   even after stopping playing the Application. Really bad!
        /// So, this was made to be sure we're not creating that buggy ghost object.
        /// </summary>
        private static bool applicationIsQuitting = false;
        public void OnDestroy()
        {
            applicationIsQuitting = true;
        }
    }
