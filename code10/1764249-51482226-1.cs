     public class HttpClient : HttpMessageInvoker
      {
    
        public HttpClient();
    
        public HttpClient(HttpMessageHandler handler);
    
        public HttpClient(HttpMessageHandler handler, bool disposeHandler);
      }
