    public ParticleSystem particleSystem; 
    private bool isPlaying = false;
    void Start() {
        particleSystem = GetComponent<ParticleSystem>();
        particleSystem.Clear();    // Reset the particles
    }
    
    void Update() {
        if(!isPlaying) {
            particleSystem.Play();
            isPlaying = true;
        }
    }
