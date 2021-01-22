    class BaseType {
      private string name;
      public BaseType(string name) {
        this.name = name;
      }
    }
    class DerivedType : BaseType {
      public DerivedType() : base("Foo") {}
    }
    
