    class SomeClass
    {
      public object MyObjectProperty { get; set; }
    }
    
    var someClass = new SomeClass();
    object someObject = new object();
    
    someClass.MyObjectProperty = someObject; // Makes MyObjectProperty point to the same location as someObject
