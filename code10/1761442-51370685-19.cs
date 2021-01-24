    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        static T instance;
    
        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = (T)FindObjectOfType(typeof(T));
                  
                    if (instance == null) Debug.LogError("Singleton of type " + typeof(T).ToString() + " not found in the scene.");
                }
    
                return instance;
            }
        }
    }
