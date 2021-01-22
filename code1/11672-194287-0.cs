    delegate void SomeFunctionDelegate(string s);
    
    void Start()
    {
      TraceAndThenCallMethod(SomeFunction, "hoho");
    }
    
    void SomeFunction(string str)
    {
      //Do stuff with str
    }
    
    void TraceAndThenCallMethod(SomeFunctionDelegate sfd, string parameter)
    {
      Trace();
      sfd(parameter);
    }
