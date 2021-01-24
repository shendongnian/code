    void Update() 
    {
        if (Input.GetMouseButtonDown(0))
        {
            btn1.onClick.AddListener(UpClicked);
        }
    }
