    class MyClass {
      private string _myBackingField = "Foo";
      private string _myOtherBackingField = "bar";
      ... stuff ...
      public string MyProperty {       
        get { return _myBackingField; }    
        set { _myBackingField = value; }
      }
      public string MyOtherProperty {       
        get { return _myOtherBackingField; }    
        set { _myOtherBackingField = value; }
      }
    }
