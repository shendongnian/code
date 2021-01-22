    class MyClass {
      private string _myBackingField = "Foo";
      public string MyProperty {       
        get { return _myBackingField; }    
        set { _myBackingField = value; }
      }
      private string _myOtherBackingField = "bar";
      public string MyOtherProperty {       
        get { return _myOtherBackingField; }    
        set { _myOtherBackingField = value; }
      }
    }
