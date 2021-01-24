    public GameObject prefab;
    public GameObject tapObject;
    private float respawnTime = 1f;
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;
    void Start()
    {
       
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Destroy(tapObject);
            StartCoroutine(spawnEnemyTime());
        }
    }
    private void RandomSpawnObject()
    {
        tapObject = GameObject.Instantiate(prefab, new Vector2(Random.Range(xMin, xMax), Random.Range(yMin, yMax)), Quaternion.identity);
    }
    IEnumerator spawnEnemyTime()
    {
        yield return new WaitForSeconds(respawnTime);
        RandomSpawnObject();
    }
