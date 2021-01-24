    private Camera _mainCamera;
    private void Awake ()
    {
        _mainCamera = Camera.main;
        //Maybe a check
        if(!_mainCamera)
        {
            Debug.LogError("No MainCamera in Scene!");
            enabled = false;
        }
    }
    void Update()
    {
        // ...
        ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
        Debug.Log(ray);
    }
