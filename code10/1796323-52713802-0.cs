    public Rigidbody2D rb;
    Vector2 cameraPos;
    
    // Set the threshold in meters
    public float Threshold = 0.1f;
    
    void Start ()
    {
        cameraPos = new Vector2(0f, -3f);
    }
    
    if (Vector3.Distance(rb.position, cameraPos) <= Threshold)
    {            
        print("Continue");
    }
