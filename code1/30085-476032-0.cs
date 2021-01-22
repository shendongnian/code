    private MyData _data = null;
    
    public MyData Data
    {
      get
      {
        if (_data == null)
          _data = LoadDataFromFile();
        return _data;
      }
    }
    
    private MyData LoadDataFromFile()
    {
      // ...
    }
