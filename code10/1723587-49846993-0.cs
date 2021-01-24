    public float playRate = 1;
    private float nextPlayTime = 0;
    
    public AudioSource shootSound;
    public AudioClip shoot;
    
    
    void Update()
    {
        if (Input.GetButton("Fire1") && (Time.time > nextPlayTime))
        {
            Debug.Log("Played");
            nextPlayTime = Time.time + playRate;
            shootSound.PlayOneShot(shoot);
        }
    }
