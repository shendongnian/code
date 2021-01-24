    void OnEnable()
    {
        enable = true;
    }
    void LateUpdate()
    {
        if (enable)
        {
            Debug.Log("enabled");
            Cursor.visible = true;
            Debug.Log(Cursor.visible);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.lockState = CursorLockMode.None;
            /*Your Cursor changing code*/
        } 
        enable = false;
    }
