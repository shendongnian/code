    public class CollisionCallback : MonoBehaviour
    {
        public delegate void CollisionAction(Collider2D collision);
        public static event CollisionAction OnTriggered;
    
        void OnTriggerEnter2D(Collider2D collision)
        {
            if (OnTriggered != null)
                OnTriggered(collision);
        }
    }
 
