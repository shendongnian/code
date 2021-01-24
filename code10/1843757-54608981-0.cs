    void Start()
        {
            columns = new GameObject[columnPoolSize];
            for (int i = 0; i < columnPoolSize; i++)
                {
                    columns[i] = (GameObject)Instantiate(columnPrefab, objectPoolPosition, Quaternion.identity);
                }
        }
