    public class Base
    {
      protected void foo()
      {
        bar();
      }
      protected void bar()
      {
        thing_a();
      }
    }
    public class Derived : Base
    {
      protected new void bar()
      {
        thing_b();
      }
    }
