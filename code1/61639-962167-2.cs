    public interface IMyInterface
    {
      void SomeMethod();
    }
    public class MyPage : IMyInterface
    {
      public void SomeMethod() { ... }
    }
    public class MyUserControl : UserControl
    {
          public void AnotherMethod()
          {
             //get the current page and cast it to the interface
             IMyInterface page = this.Page as IMyInterface;
             // now I can call the methods of the interface
             if (page != null) page.SomeMethod();
          }
    }
