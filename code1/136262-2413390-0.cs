    [Serialiable] 
    class Foo { 
      public object Field;
    }
    class Bar { }
    
    var value = new Foo() { Field1 = 42; } // value is serializable
    value.Field1 = new Bar();  // value is no longer serializable
