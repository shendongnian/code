    
    public class GameManager : MonoBehaviour
    {
        public static Instance
        {
            get
            {
                if (isDestroyed) return null;
    
                // Your spawn logic...
            }
        }
    
        static bool isDestroyed;
        static GameManager()
        {
           isDestroyed = false;
        }
    
        void OnDestroy()
        {
            isDestroyed = true;
        }
    }
