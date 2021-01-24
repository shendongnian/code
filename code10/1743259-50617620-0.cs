    public class TestModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.BeginRequest += OnBeginRequest;
        }
    
        static void OnBeginRequest(object sender, EventArgs a)
        {
            Debug.WriteLine("OnBeginRequest Called MVC");        
        }
    
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
