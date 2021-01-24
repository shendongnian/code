    public GameObject prefab;
    public float offset = 2f;
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Camera cam = Camera.main;
    
            Vector2 mousePos = Vector3.zero;
    
            mousePos.x = Input.mousePosition.x;
            mousePos.y = Input.mousePosition.y;
    
            Vector3 worldPoint = cam.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, cam.nearClipPlane + offset));
    
            Instantiate(prefab, worldPoint, Quaternion.identity);
        }
    }
