    private static Manager _manager;
    
    public static Manager Manager
    {
       get 
       {
          if (_manager == null)
          {
             _manager = new Manager();
          }
          return instance;
       }
    }
