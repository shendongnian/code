    public class GlobalTimer : MonoBehaviour
    {
        public float Delay = 2.0f;
        public UnityEvent onTimerDone;
        // Unity allows to use Start as IEnumerator instead of a void
        private IEnumerator Start()
        {
            yield return new WaitforSeconds(delay);
            onTimerDone.Invoke();
        }
    }
