    public AnimationCurve SpeedOverTime ; // Change the curve in the inspector
    private float startTime ;
    
    void Start()
    {
        startTime = Time.time ;
    }
    
    void Update ()
    {
        // Multiplying by Time.deltaTime is advised in order to be frame independant
        transform.Translate (0, SpeedOverTime.Evaluate( Time.time - startTime ) * Time.deltaTime , 0);
    }
