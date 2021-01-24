    // Enemies will spawn for 5 seconds.
    private float spawnTimer = 5f;
    private void Update()
    {
        if (spawnTimer > 0)
        {
            spawnTimer -= Time.deltaTime;
            if (spawnTimer <= 0)
            {
                StopSpawning();
            }
        }
    }
