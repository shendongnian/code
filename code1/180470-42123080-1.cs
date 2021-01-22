    class HttpCompressionModule : IHttpModule
    {
      private IDisposalbe _myResource;
      
      public void Init(HttpApplication application)
      {
        _myResource = new MyDisposableResource();
        application.SomeEvent += OnSomeEvent;
      }
    
      private void OnSomeEvent(Object source, EventArgs e)
      {
        // ...
        myResource.DoSomething();
      }
    
      public void Dispose() 
      {
        _myResource.Dispose();
      } 
    }
