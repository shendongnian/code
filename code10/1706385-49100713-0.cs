    public void HandleInputC ()
    {
        Debug.Log("C was pressed (or simulated).");
    }
    public void HandleInputD ()
    {
        Debug.Log("D was pressed (or simulated).");
    }
    
    private void Update ()
    {
        if (Input.GetKeyDown("c"))
            HandleInputC();
        if (Input.GetKeyDown("d"))
            HandleInputD();
    }
