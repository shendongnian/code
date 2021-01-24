    Transform cameraTransform;
    public float shootSpeed = 300;
    public Rigidbody rbdy;
    
    void Start()
    {
        cameraTransform = Camera.main.transform;
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 velocity = cameraTransform.forward * shootSpeed;
    
            PredictResult result;
            if (PredictRigidBodyLandPos(rbdy, velocity, out result))
            {
    
                Debug.Log("DONE Predicting Landing Pos: x " + result.position.x + " y:"
                + result.position.y + " z:" + result.position.z);
                Debug.Log("Landing Time: " + result.landingTime);
            }
            else
            {
                Debug.Log("Failed to predict landing pos before timeout");
            }
        }
    }
