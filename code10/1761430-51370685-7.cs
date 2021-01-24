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
                }
    
                return instance;
            }
        }
    }
