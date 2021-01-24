    using UnityEngine;
    
    
    public abstract class SingletonBehaviour<T> : MonoBehaviour where T : MonoBehaviour
    {
        public bool dontDestroyOnLoad = true;
        private bool isInitialized = false;
        private static T instance;
        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<T>();
                    if (instance == null)
                    {
                        var obj = new GameObject
                        {
                            name = typeof(T).Name
                        };
                        instance = obj.AddComponent<T>();
                    }
                }
                return instance;
            }
        }
        protected virtual void Awake()
        {
            if (instance == null)
            {
                instance = this as T;
                if (dontDestroyOnLoad)
                {
                    DontDestroyOnLoad(this.transform.root.gameObject);
                }
            }
            else if (instance != this)
            {
                Destroy(gameObject);
            }
        }
        private void OnEnable()
        {
            if (!isInitialized)
            {
                OnInitialize();
                isInitialized = true;
            }
        }
        public abstract void OnInitialize();
    }
    
