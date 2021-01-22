    class StreamHolder : IDisposable
    {
      List<Stream> Streams {get;}
    
      public void  Dispose()
      {
          Streams.ForEach(x=>x.Dispose()):
      }
    }
