    private ParticleSystem ps;
    
    // Use this for initialization
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }
    
    // Update is called once per frame
    void Update()
    {
        Debug.Log("Particles Count: " + ps.particleCount);
        Debug.Log("Particles Alive Count: " + GetAliveParticles());
    }
    
    int GetAliveParticles()
    {
        ParticleSystem.Particle[] particles = new ParticleSystem.Particle[ps.particleCount];
        return ps.GetParticles(particles);
    }
