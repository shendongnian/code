    public class MyHandler : IHttpHandler, IReadOnlySessionState
    {
      public void ProcessRequest(HttpContext context) 
      {
        //You can use session here
      }
      public bool IsReusable { get { return true; } } //this may vary for you
    }
