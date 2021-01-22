    public interface IFoo<T> where T : new()
    {
      void SomeMethod();
    }
    public class Foo : IFoo<Foo>
    {
      // This will not compile
      public Foo(int x)
      {
      }
      #region ITest<Test> Members
      public void SomeMethod()
      {
        throw new NotImplementedException();
      }
      #endregion
    }
