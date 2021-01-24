    public Dictionary<string, GameObject> prefabDict = new Dictionary<string, GameObject>();
    public void SpawnPrefabFromDict(string name)
    {
        Instantiate(prefabDict[name]);
    }
