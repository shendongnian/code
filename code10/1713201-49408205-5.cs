    int i = 0;
    void Update()
    {
        //if spawning is active then continue...
        if (i < action.quantityOfEnemysToSpawn) 
        {
            if (timeLeftToSpawnEnemy < action.spawnRate) 
            {
                timeLeftToSpawnEnemy += Time.deltaTime;
            }
            else
            {
                i++;
                GameObject.Instantiate (action.enemyToSpawn, spawnLocations [currentSpawnToInstantiate].position, Quaternion.identity);
                currentSpawnToInstantiate++;
    
                timeLeftToSpawnEnemy = 0f;
    
                if (currentSpawnToInstantiate >= numberOfSpawns)
                    currentSpawnToInstantiate = 0;
            }
        }
    }
