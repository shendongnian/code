    public class Base
    {
      protected void foo()
      {
        bar();
      }
      protected virtual void bar()
      {
        thing_a();
      }
    }
    public class Derived : Base
    {
      protected override void bar()
      {
        thing_b();
      }
    }
