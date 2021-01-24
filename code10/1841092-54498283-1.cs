        if (!spawnPositions.Any(array => array.IsContentEqualTo(rnd)))
        {
            Debug.Log("SpawnPos Added!");
            spawnPositions.Add(rnd);
        }
