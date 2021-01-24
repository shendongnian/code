    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            SpawnSpaceRock();
        }
        // TODO: Maybe later remove null elements for better performance
        // Run each move towards
        foreach(var kvp in MissileToAsteroid)
        {
            var missile = kvp.key;
            var asteroid = kvp.value;
            missile.transform.MoveTowards(missile.transform.possition, asteroid.transform.position, speed * Time.deltaTime);
        }
    }
