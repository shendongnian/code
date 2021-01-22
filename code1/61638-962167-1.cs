    public class MyUserControl : UserControl
    {
      public void AnotherMethod()
      {
         //get the current page and cast it to its type
         MyPage page = this.Page as MyPage;
         // now I can call the public methods of MyPage
         page.SomeMethod();
      }
      ...
    }
