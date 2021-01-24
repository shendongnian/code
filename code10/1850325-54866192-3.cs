    // Hint of you use the correct component type here
    // you don't even have to use GetComponent later
    public launch MissilePrefab;
    public GameObject Asteroideprefab;
    //...
    public void SpawnSpaceRock()
    {
        Vector3 pos = center + new Vector3(Random.Range(-size.x / 2, size.x / 2), Random.Range(-size.y / 2, size.y / 2), Random.Range(-size.z / 2, size.z / 2));
        // store reference of Instantiated GameObject
        var asteroide =  Instantiate(Asteroidprefab, pos, Quaternion.identity);
        // Store reference of Instantiated launch componemt
        var missile = Instantiate(Missileprefab, ship, Quaternion.identity);
        // Now set the taregt
        missile.Target = asteroid;
    }
