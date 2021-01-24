    void OnEnable()
    {   
        _manager.TestDelegate += Test;
    }
    void OnDisable()
    {   
        _manager.TestDelegate -= Test;
    }
