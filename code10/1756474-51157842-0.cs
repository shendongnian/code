    public GameObject ball; //the prefab you want to spawn
    private GameObject spawnedball; //a local temporary reference
    public void BallSpawn(){
        spawnedball = Instantiate (ball, ballSpawnTransform.position, ballSpawnTransform.rotation);
    }
