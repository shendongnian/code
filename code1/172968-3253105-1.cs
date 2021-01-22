    class Foo
    {
      protected void SomeMethod(ref string theStr) { ... }
      ...
    }
    class TestableFoo
    {
      public void TestableSomeMethod(ref string theStr)
      {
        base.SomeMethod(...);
      }
      ...
