    public class SocketState : IDisposable
    {
      Socket _socket;
      public SocketState()
      {
        _socket = new Socket();
      }
      public bool IsDisposed { get; private set; }
      public void SomeMethod()
      {
        if (IsDisposed)
          throw new ObjectDisposedException("SocketState");
        // Some other code
      }
      #region IDisposable Members
      public void Dispose()
      {
        Dispose(true);
        GC.SuppressFinalize(this);
      }
      protected virtual void Dispose(bool disposing)
      {
        if (!IsDisposed)
        {
          if (disposing)
          {
            if (_socket != null)
            {
              _socket.Close();
            }
          }
          // disposed unmanaged resources
          IsDisposed = true;
        }
      }
      ~SocketState()
      {
        Dispose(false);
      }
      #endregion
    }
