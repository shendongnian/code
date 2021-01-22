    class MyClass {
       ... stuff ...
    
      private string _myBackingField = "Foo";
      public string MyProperty {       
        get { return _myBackingField; }    
        set { _myBackingField = value; }
      }
    }
