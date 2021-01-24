    void Update()
    {
        if (timeBtwSpawns <= 0)
        {
            if(spawneable)
            {
               int randPos = Random.Range(0, spawnSpots.Length);
               Instantiate(duck, spawnSpots[randPos].position, Quaternion.identity);
               timeBtwSpawns = startTimeBtwSpawns;
            }
        }
        else
        {
            timeBtwSpawns -= Time.deltaTime;
        }
    }
