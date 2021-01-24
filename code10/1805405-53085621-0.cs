    public class YourBaseClass : MonoBehaviour
    {
        protected virtual void Awake()
        {
            Debug.Log("Awake Base");
    
        }
    
        protected virtual void Start()
        {
            Debug.Log("Start Base");
        }
    
        protected virtual void Update()
        {
            Debug.Log("Update Base");
        }
    
        protected virtual void FixedUpdate()
        {
            Debug.Log("FixedUpdate Base");
        }
    }
