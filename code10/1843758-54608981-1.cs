    private GameObject[] instantiatedColumns;
    public GameObject[] columnPrefabs;
    void Start()
        {
            instantiatedColumns= new GameObject[columnPrefabs.Length];
            for (int i = 0; i < columnPrefabs.Length; i++)
                {
                    instantiatedColumns[i] = Instantiate(columnPrefabs[i], objectPoolPosition, Quaternion.identity);
                }
        }
