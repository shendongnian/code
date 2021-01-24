    
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance
        {
            get
            {
                if (isDestroyed) return null;
    
                // Your spawn logic...
            }
        }
    
        static bool isDestroyed;
    
        void OnDestroy()
        {
            isDestroyed = true;
        }
    }
