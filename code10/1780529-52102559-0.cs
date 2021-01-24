    [ExecuteInEditMode]
    public class YourClass : MonoBehaviour
    {
        void Update()
        {
            if (!Application.isPlaying)
            {
                Debug.Log("This should only run in edit mode.");
                // More code
            }
        }
    }
