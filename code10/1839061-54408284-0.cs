    void Start()
    {     
        StartCoroutine(spawnEnemyTime());
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {           
            tapObject.SetActive(false);
        }      
    }
    private void RandomSpawnObject()
    {     
        tapObject.SetActive(true); 
        tapObject.transform.position = new Vector2(Random.Range(xMin, xMax), Random.Range(yMin, yMax));
    } 
    IEnumerator spawnEnemyTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            RandomSpawnObject();
        }
    }
