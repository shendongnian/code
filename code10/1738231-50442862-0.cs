    public class ServerAClient {
      private HttpClient _client;
      private static object _locker = new object();
    
      public static HttpClient GetInstance() {
        if (_client == null) {
          lock (_locker) {
            // create your httpclient here
            _client = instance;
          }
        }
    
        return _client;
      }
    }
    public class MyController : Controller {
      private readonly ServerAClient _aclient;
      public MyController(ServerAClient Aclient) {
        _aclient = Aclient;
      }
    
      public IHttpAction Index() {
        ...
       _aclient.DoSomething();
      }
    }
