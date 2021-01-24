    public class ActivateDialogueTrigger : MonoBehaviour
    {
        // Drag & drop the objects in the inspector
        public GammeObject[] YourGameObjects ;
    
        // You will be able to add a function once all the objects are destroyed
        public UnityEngine.Events.UnityEvent OnAllObjectsDestroyed;
        
        void Update ()
        {
            CheckAllObjectsAreDestroyed();
        }
        
        private void CheckAllObjectsAreDestroyed ()
        {    
            for( int i = 0 ; i < YourGameObjects.Length ; ++i )
            {
                if( YourGameObjects[i] != null )
                    return ;
            }
    
            if( OnAllObjectsDestroyed != null )
                OnAllObjectsDestroyed.Invoke() ;       
        }
    
    }
