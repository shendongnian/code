    class MyClass {
      internal MyClass(MyClassBuilder builder) {
         MyProp1 = builder.MyProp1;
         MyProp2 = builder.MyProp2;
         MyProp3 = builder.MyProp3;
      }
      public string MyProp1 { get; }
      public string MyProp2 { get; }
      public string MyProp3 { get; }
    }
    class MyClassBuilder {
      public string MyProp1 { get; set; }
      public string MyProp2 { get; set; }
      public string MyProp3 { get; set; }
      public MyClass Build() => new MyClass(this);
    }
