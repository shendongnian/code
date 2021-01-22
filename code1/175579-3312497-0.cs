    interface IFoo {
      void MethodA();
      void MethodB();
    }
    abstract class Base: IFoo {
      public void MethodA() {}
      // MethodB gets implicitly generated
    }
    class Derived: Base {
      public void MethodB() {}
    }
