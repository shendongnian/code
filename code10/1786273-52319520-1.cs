    public class MainScript : MonoBehaviour
    {
        void OnEnable()
        {
            //Register to OnTriggered event
            CollisionCallback.OnTriggered += TriggerDetected;
        }
    
    
        void OnDisable()
        {
            //Un-Register to OnTriggered event
            CollisionCallback.OnTriggered -= TriggerDetected;
        }
    
    
        //This is invoked when trigger happens
        void TriggerDetected(Collider2D collision)
        {
            Debug.Log("Trigger happened with: " + collision.name);
        }
    }
