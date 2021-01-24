    public static T GetInstance
    {
        get
        {   
           if (_instance == null)
             _instance = new Lazy<T>(() => CreateSingletonInstance());
           return _instance.Value;
        }
    }
    public static void ReleaseInstance
    {
        _instance = null;
    }
