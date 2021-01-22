    public class MyUserControl : UserControl
    {
      private void SomeOtherMethod()
      {
        // page must implement ISomeService, throws an exception otherwise
        (Page as ISomeService).Method1();
      }
    }
