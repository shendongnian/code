    interface ISomeInterface
    {
      string SomeMethodName();
    }
    class SomeImplementation : ISomeInterface
    {
      public static Instance { get { return new SomeImplementation(); } }
      public string SomeMethodName()
      {
        // implementation of SomeMethodName
      }
    }
    
    public Get(ISomeInterface i)
    {
       string s = i.SomeMethodName();
    }
    public Example()
    {
      Get(SomeImplementation.Instance);
    }
