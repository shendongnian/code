    public class ActivateDialogueTrigger : MonoBehaviour
    {
        // Drag & drop the objects in the inspector
        public OnDestroyDispatcher[] OnDestroyDispatchers ;
    
        // You will be able to add a function once all the objects are destroyed
        public UnityEngine.Events.UnityEvent OnAllObjectsDestroyed;
        
        void Start ()
        {
        
            for( int i = 0 ; i < OnDestroyDispatchers.Length ; ++i )
                OnDestroyDispatchers[i].OnObjectDestroyed += OnObjectDestroyed ;
        }
        
        
        private void OnObjectDestroyed (GameObject destroyedObject)
        {
    
            CheckAllObjectsAreDestroyed();       
        }
        
        
        private void CheckAllObjectsAreDestroyed ()
        {    
            for( int i = 0 ; i < OnDestroyDispatchers.Length ; ++i )
            {
                if( OnDestroyDispatchers[i] != null || OnDestroyDispatchers[i].gameObject != null )
                    return ;
            }
    
            if( OnAllObjectsDestroyed != null )
                OnAllObjectsDestroyed.Invoke() ;       
        }
    
    }
