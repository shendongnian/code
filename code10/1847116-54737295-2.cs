    void Start () {
		ParticleSystem ps = gameObject.GetComponent<ParticleSystem>();
		ParticleSystem.MainModule psMain = ps.main;
		ParticleSystem.MinMaxGradient minMaxGradient = new ParticleSystem.MinMaxGradient(Color.red, Color.white);
		psMain.startColor = minMaxGradient;
    }
