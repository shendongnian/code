    IEnumerator SpawnEnemy ()
    {
        while (true) // Keep checking
        {
            if(_uimanager.playerExists == true)
            {
                Vector3 position = new Vector3(Random.Range(-8.23f, 8.23f), 5.7f, 0.0f);
                Instantiate(_enemyShipPrefab, position, Quaternion.identity);
            }
            yield return new WaitForSeconds (5.0f); // Wait between checks 5secs
        }
    }
