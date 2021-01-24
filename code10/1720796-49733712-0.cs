    private ParticleSystem _particleSystem;
    private ParticleSystem.EmissionModule _emissionModule;
    private void Awake()
    {
        _particleSystem = GetComponent<ParticleSystem>();
        _emissionModule = _particleSystem.emission;
        _emissionModule.enabled = false;
    }
	private void OnCollisionEnter(Collision collision) 
	{
		_emissionModule.enabled = true;
		_particleSystem.Play();
	}
