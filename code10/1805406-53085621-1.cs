    public class Parent : YourBaseClass
    {
        protected override void Awake()
        {
            base.Awake();
            Debug.Log("Awake Parent");
        }
    
        protected override void Start()
        {
            base.Start();
            Debug.Log("Start Parent");
        }
    
        protected override void Update()
        {
            base.Update();
            Debug.Log("Update Parent");
        }
    
        protected override void FixedUpdate()
        {
            base.FixedUpdate();
            Debug.Log("FixedUpdate Parent");
        }
    }
