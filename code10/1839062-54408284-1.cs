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
            tapObject.SetActive(false);
            StartCoroutine(spawnEnemyTime());
        }
    }
    private void RandomSpawnObject()
    {
        tapObject.SetActive(true);
        tapObject.transform.position = new Vector2(Random.Range(xMin, xMax), Random.Range(yMin, yMax));
    }
    IEnumerator spawnEnemyTime()
    {
        yield return new WaitForSeconds(respawnTime);
        RandomSpawnObject();
    }
