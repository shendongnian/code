    // Invoke the method after interval seconds
    public float interval = 0.1f;
    float delaySeconds = 0f; // delay the first call by seconds
    void Start()
    {
        InvokeRepeating("TakeShot", delaySeconds, interval);
    }
    void TakeShot() 
    {
       // do your thing here...
    }
