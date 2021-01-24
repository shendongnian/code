    public Light point_light;
    public float speed = 0.36f;
    
    float intensity1 = 3.08f;
    float intensity2 = 1.0f;
    
    
    void Start()
    {
        point_light = GetComponent<Light>();
    }
    
    void Update()
    {
        //PingPong between 0 and 1
        float time = Mathf.PingPong(Time.time * speed, 1);
        point_light.intensity = Mathf.Lerp(intensity1, intensity2, time);
    }
