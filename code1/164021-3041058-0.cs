    public interface ISomeService
    {
      void Method1();
      bool Method2();
    }
    
    public class MyContentPage : Page, ISomeService
    {
      void Method1() { ... }
      bool Method2() { ... }
    
      override OnLoad(...)
      {
        TheUserControl.SetService(this as ISomeService);
      }
    }
    
    public class MyUserControl : UserControl
    {
      public void SetService(ISomeService service)
      {
        _service = service;
      }
    
      private void SomeOtherMethod()
      {
        _service.Method1();
      }
    }
