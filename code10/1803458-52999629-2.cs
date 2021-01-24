    public class YourDeactivatableScript: MonoBehaviour
    {
        public IEnumerator Load()
        {
            yield return new WaitForSeconds(waitTime);
            gameObject.SetActive(true);
        }
    }
