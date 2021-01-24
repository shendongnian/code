    public float speed;
    private Dictionary<launch, GameObject> MissileToAsteroid = new Dictionary<launch, GameObject>(); 
    public void SpawnSpaceRock()
    {
        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
        // store reference of Instantiated GameObject
        var asteroide =  Instantiate(Asteroidprefab, pos, Quaternion.identity);
        // Store reference of Instantiated launch componemt
        var missile = Instantiate(Missileprefab, ship, Quaternion.identity);
        // Since launch is still responsible for different both objects
        // you still need to pass the reference
        missile.Target = asteroid;
        // Add to dictionary
        MissileToAsteroid [missile] = asteroid;
    }
    
