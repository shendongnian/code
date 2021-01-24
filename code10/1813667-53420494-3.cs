    public GameObject eggPrefab;
    public Vector3 spawnPos;
    public Material mat;
    
    void Start()
    {
        GameObject obj = Instantiate(eggPrefab, spawnPos, Quaternion.identity);
        obj.GetComponent<MeshRenderer>().material = mat;
    }
