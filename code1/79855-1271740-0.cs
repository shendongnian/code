    private static Repository Instance
    {
      get
      {
        return _repository ?? Repository.Instance;
      }
    }
    private static Repository _repository = null;
    
    public static void Save(this Entity data)
    {
      Instance.Save(data);
    }
