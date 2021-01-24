    public GameObject prefab;
    public float offset = 10f;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 clickPos;
    
            clickPos = Input.mousePosition;
            clickPos.z = offset;
    
            clickPos = Camera.main.ScreenToWorldPoint(clickPos);
            GameObject obj = Instantiate(prefab, clickPos, Quaternion.identity);
        }
    }
