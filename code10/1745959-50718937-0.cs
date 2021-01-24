    private float fireTimer = 1.0f;
    public float fireLimiter = 0.05f;
    void Fire(float firingRate)
    {
        TimePerFrame += Time.deltaTime;
        if(TimePerFrame >= firingRate)
        {
            Vector3 ProjectileDistance = new Vector3(0, 30, 0); //distance between center of the campion and it's head
            GameObject beam = Instantiate(projectile, transform.position + ProjectileDistance, Quaternion.identity) as GameObject;
            beam.GetComponent<Rigidbody2D>().velocity = new Vector3(0, projectileSpeed, 0);
            //  AudioSource.PlayClipAtPoint(fireSound, transform.position);
            TimePerFrame = 0;
        }
    }
    
    void Update ()
    {
        if (freezePosition == false)
        {
            if(fireTimer > 0.0f){
                fireTimer -= Time.deltaTime * fireLimiter;
            }
            Fire(firingRate);
            PositionChaning();
            firingRate = Mathf.Lerp(minFiringRate, maxFiringRate, fireTimer);
            Debug.Log(firingRate);
        }
    }
