    class MyClass {
       ... stuff ...
      public MyClass() {
          MyProperty = "Foo";
      }
      [DefaultValue("Foo")]
      public string MyProperty { get;set; }
    }
