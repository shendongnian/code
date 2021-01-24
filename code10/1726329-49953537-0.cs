    private readonly List<GameObject> objectListCache = new List<GameObject>();
    private void Update()
    {
        cachedObjectList.Clear();
        cachedObjectList.Add(GameObject.Find("Player1"));
        cachedObjectList.Add(GameObject.Find("Player2"));
        cachedObjectList.Add(GameObject.Find("Enemy1"));
        cachedObjectList.Add(GameObject.Find("Enemy2"));
        cachedObjectList.Add(GameObject.Find("Enemy3"));
        Vector3 newPos = new Vector3(0, 0, 0);
        moveObjects(newPos, 3f, cachedObjectList);
        cachedObjectList.Clear();
    }
    
    void MoveObjects(Vector3 newPos, float duration, List<GameObject> objs)
    {
        foreach (GameObject obj in objs)
        {
            // ...
        }
    }
