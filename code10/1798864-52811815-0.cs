    public class IHttpDelegate {
      void run();
    }
    
    public abstract class HttpDelegate : IHttpDelegate {
    
      public HttpClient httpClient;
    
      public HttpDelegate(Uri uri) {
        this.httpClient = new HttpClient(uri);
      }
    
      protected httpClient {
        get {
          return this.httpClient ;
        }
      }
    }
    
    public class HttpPostDelegate : HttpDelegate {
    
      private HttpContect httpContent;
    
      public HttpPostDelegate (Uri uri) : base(uri) {
        this.httpContent = httpContent;
      }
    
      public HttpContect httpContent {
        get {
          return this.httpContent;
        }
      }
    
      public void run() {
        httpClient.PostAync(httpContent);
      }
    
    }
    
    public class HttpDeleteDelegate : HttpDelegate {
    
      public HttpDeleteDelegate (Uri uri) : base(uri) {
      }
    
      public void run() {
        httpClient.DeleteAync();
      }
    
    }
