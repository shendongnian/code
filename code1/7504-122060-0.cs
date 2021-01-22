    private static Assembly _assembly;
    private static Assembly Assembly {
      get {
        if (_assembly == null) _assembly = Assembly.GetExecutingAssembly();
        return _assembly;
      }
    }
    
    private static Assembly _calling_assembly;
    private static Assembly CallingAssembly {
      get {
        if (_calling_assembly == null) _calling_assembly = Assembly.GetCallingAssembly();
        return _calling_assembly;
      }
    }
