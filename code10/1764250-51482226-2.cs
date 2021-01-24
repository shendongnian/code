    namespace System.Net.Http
    {
      public class HttpClientHandler : HttpMessageHandler
      {
          ...
      }
      ///oops, it's an abstract class 
      public abstract class HttpMessageHandler : IDisposable
      {
          ...
      }
    }
