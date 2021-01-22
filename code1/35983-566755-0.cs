    public class MessagingServices
    {
      public static IAsyncResult BeginReverseEcho (TcpClient client,
                                                   AsyncCallback callback,
                                                   object userState)
      {
        var re = new ReverseEcho(  );
        re.Begin (client, callback, userState);
        return re;
      }
    
      public static byte[] EndReverseEcho (IAsyncResult r)
      {
        return ((ReverseEcho)r).End(  );
      }
    }
    
    class ReverseEcho : IAsyncResult
    {
      volatile TcpClient     _client;
      volatile NetworkStream _stream;
      volatile object        _userState;
      volatile AsyncCallback _callback;
      ManualResetEvent       _waitHandle = new ManualResetEvent (false);
      volatile int           _bytesRead = 0;
      byte[]                 _data = new byte [5000];
      volatile Exception     _exception;
    
      internal ReverseEcho(  ) { }
    
      // IAsyncResult members:
    
      public object AsyncState           { get { return _userState;  } }
      public WaitHandle AsyncWaitHandle  { get { return _waitHandle; } }
      public bool CompletedSynchronously { get { return false;       } }
      public bool IsCompleted
      {
       get { return _waitHandle.WaitOne (0, false); }
      }
    
      internal void Begin (TcpClient c, AsyncCallback callback, object state)
      {
        _client = c;
        _callback = callback;
        _userState = state;
        try
        {
          _stream = _client.GetStream(  );
          Read(  );
        }
        catch (Exception ex) { ProcessException (ex); }
      }
    
      internal byte[] End(  )     // Wait for completion + rethrow any error.
      {
        AsyncWaitHandle.WaitOne(  );
        AsyncWaitHandle.Close(  );
        if (_exception != null) throw _exception;
        return _data;
      }
    
      void Read(  )   // This is always called from an exception-handled method
      {
        _stream.BeginRead (_data, _bytesRead, _data.Length - _bytesRead,
                           ReadCallback, null);
      }
    
      void ReadCallback (IAsyncResult r)
      {
        try
        {
          int chunkSize = _stream.EndRead (r);
          _bytesRead += chunkSize;
          if (chunkSize > 0 && _bytesRead < _data.Length)
          {
            Read(  );       // More data to read!
            return;
          }
          Array.Reverse (_data);
          _stream.BeginWrite (_data, 0, _data.Length, WriteCallback, null);
        }
        catch (Exception ex) { ProcessException (ex); }
      }
    
      void WriteCallback (IAsyncResult r)
      {
        try { _stream.EndWrite (r); }
        catch (Exception ex) { ProcessException (ex); return; }
        Cleanup(  );
      }
    
      void ProcessException (Exception ex)
      {
        _exception = ex;   // This exception will get rethrown when
        Cleanup();         // the consumer calls the End(  ) method.
      }
    
      void Cleanup(  )
      {
        try
        {
          if (_stream != null) _stream.Close(  );
        }
        catch (Exception ex)
        {
          if (_exception != null) _exception = ex;
        }
        // Signal that we're done and fire the callback.
        _waitHandle.Set(  );
        if (_callback != null) _callback (this);
      }
    }
