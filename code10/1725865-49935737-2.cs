    private ParticleSystem explosionSystem;
    void Start()
    {
        GameObject obj = GameObject.Find("NameOfObjectParticleSystemIsAttachedTo");
        explosionSystem = obj.GetComponent<ParticleSystem>();
    }
