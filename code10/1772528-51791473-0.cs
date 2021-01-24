    float totaltime;
    void Start()
    {
        Music = GetComponent<AudioSource>();
        AudioClip MusicClip;
        MusicClip = Music.clip;
        MusicClipLength = Music.clip.length;   //time
        distance = ((((0.5f * 0.25f) * (MusicClipLength * MusicClipLength))));   //distance
        float RoundedDistance = (float)Mathf.Floor(distance);   //rounding
        StartCoroutine(Spawner());
    }
    
    void IEnumerator Spawner()
    {
        totaltime += Time.deltaTime;
        while (totaltime < MusicClipLength)
        {
            Instantiate(Object, new Vector3(0, i * 1750.0f, 500), Quaternion.Euler(-90, 0, 90));
            yield return new WaitForSeconds(rocketspeedFactor); // you should mess around with this value to get the spawning frequency correct. 
            // would be good to retrieve the speed from the rocket and multiple by some factor
        }
    
    }
