    private IEnumerator GenerateHazard()
    {
        while (true)
        {
            timeBetweenSpawns = Random.Range(0.5f, 2.0f); //Testing values
            amountOfHazardsToSpawn = Random.Range(1, 6);  //Testing values
            for (int i = 0; i < amountOfHazardsToSpawn; i++)
            {
                Vector3 spawnPos = new Vector3(Random.Range(minX, maxX), 15.0f, 0.0f); // generate spawn position
                Instantiate(hazards[hazardsToSpawn], spawnPos, Quaternion.identity);  //spawn hazards
            }
            yield return new WaitForSeconds(timeBetweenSpawns);
        }
    }
