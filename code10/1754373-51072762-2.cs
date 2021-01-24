    private Camera cam1;
    
    // Use this for initialization
    void Start()
    {
        GameObject obj = GameObject.Find("Main Camera");
        cam1 = obj.GetComponent<Camera>();
    }
