    public sealed class ClassA : IMethodA {    
      private ClassA() { }
      private void Initialize(IMethodA param) { ... }
      public static ClassA Create() {
        var v1 = new ClassA();
        v1.Initialize(v1);
        return v1;
      }
      public static ClassA Create(IMethodA param) {
        var v1 = new ClassA();
        v1.Initialize(param);
        return v1;
      }
    }
