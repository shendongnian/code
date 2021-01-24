    public class CubeTracker : MonoBehaviour
    {
        private bool logging = true;
    
        void  Awake()
        {
            StartCoroutine(LogPosition());
        }
    
        private IEnumerator LogPosition()
        {
            while (logging)
            {
                Debug.Log(transform.position);
                yield return new WaitForSeconds(3f);
            }
        }
    }
