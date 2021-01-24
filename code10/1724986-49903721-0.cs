    public class OnDestroyDispatcher : MonoBehaviour
    {
        public event System.Action<GameObject> OnObjectDestroyed ;
        private void OnDestroy()
        {
            if( OnObjectDestroyed != null ) OnObjectDestroyed( gameObject ) ;
        }
    }
