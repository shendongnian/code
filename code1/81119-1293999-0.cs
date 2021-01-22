    public static MyGlobals
    {
      public string Global1 = "Hello";
      public string Global2 = "World";
    }
    
    public Foo
    {
    
        private void Method1()
        {
           string example = MyGlobals.Global1;
           //etc
        }
    }
