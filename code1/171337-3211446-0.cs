    private static Assembly _entryAssembly;
    
    private Assembly ExecutingAssembly
    {
      get 
      { 
        if (_entryAssembly == null )
        {
          _assembly = Assembly.GetEntryAssembly();
        }
        return _entryAssembly
    }
