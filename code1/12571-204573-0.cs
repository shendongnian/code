    abstract MyBase
    {
      public string Name;
      protected MyBase()
      {
        //look up value of Name attribute and assign to Name
      } 
    }
    
    [Name("Foo")]
    class MyClass : MyBase
    {
    }
