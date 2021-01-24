    void Awake () {
        for (int x = 0; x < numberOfInstances; x++) {
            ObstacleSpawned obsItem = new ObstacleSpawned();
            for (int y = 0; y < obstacles.Length; y++) {
                GameObject obstacle = Instantiate (obstacles [y].prefab, transform) as GameObject;
                obstacle.name = obstacles [y].name;
                obstacle.SetActive (false);
                //obsItem.spawnedObstacles.Add (obstacle);
                print (obsItem.spawnedObstacles);
            }
            obstaclesSpawned.Add (obsItem);
        }
    }
