    public class GlobalTimer : MonoBehaviour
    {
        public List<UnityEvent> events;
        public List<float> delays;
    
        private void Start()
        {
            var validPairs = Mathf.Min(events.Count, delays.Count);
    
            for (int i = 0; i < validPairs; i++)
            {
                StartCoroutine(InvokeDelayed(events[i], delays[i]));
            }
        }
    
        private IEnumerator InvokeDelayed(UnityEvent unityEvent, float delay)
        {
            yield return new WaitForSeconds(delay);
    
            unityEvent.Invoke();
        }
    }
