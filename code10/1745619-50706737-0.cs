    public class OtherScript : MonoBehaviour
    {
        private static OtherScript instance;
    
        public static OtherScript Instance { get { return instance; } }
    
        private void Awake()
        {
            instance = this;
        }
    
        public void DoSomething()
        {
            Debug.Log("Call");
        }
    }
