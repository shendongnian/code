    public interface MyInterface {
      void Method();
    }
    public class Base {
      public void Method() { }
    }
    public class Derived : Base, MyInterface { }
