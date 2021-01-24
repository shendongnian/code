    public GameObject eggPrefab;
    public Vector3 spawnPos;
    public Material[] mats;
    void Start()
    {
        GameObject obj = Instantiate(eggPrefab, spawnPos, Quaternion.identity);
        int matIndex = UnityEngine.Random.Range(0, mats.Length);
        obj.GetComponent<MeshRenderer>().material = mats[matIndex];
    }
