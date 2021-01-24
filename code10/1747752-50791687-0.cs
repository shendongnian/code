    public float xMoveThreshold = 1000.0f;
    public float yMoveThreshold = 1000.0f;
    
    public float yMaxLimit = 45.0f;
    public float yMinLimit = -45.0f;
    
    
    float yRotCounter = 0.0f;
    float xRotCounter = 0.0f;
    
    Transform mainCam;
    
    void Start()
    {
        mainCam = Camera.main.transform;
    }
    
    // Update is called once per frame
    void Update()
    {
        xRotCounter += Input.GetAxis("Mouse X") * xMoveThreshold * Time.deltaTime;
        yRotCounter += Input.GetAxis("Mouse Y") * yMoveThreshold * Time.deltaTime;
        yRotCounter = Mathf.Clamp(yRotCounter, yMinLimit, yMaxLimit);
        //xRotCounter = xRotCounter % 360;//Optional
        mainCam.localEulerAngles = new Vector3(-yRotCounter, xRotCounter, 0);
    }
