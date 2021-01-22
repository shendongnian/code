    static void UploadFile(string file) {
      for (int attempt = 0; ; ++attempt) {
        try {
          UploadToServer(file);
          return;
        }
        catch (SocketException ex) {
          if (attempt < 10 && (
              ex.SocketErrorCode == SocketError.ConnectionAborted ||
              ex.SocketErrorCode == SocketError.ConnectionReset ||
              ex.SocketErrorCode == SocketError.Disconnecting ||
              ex.SocketErrorCode == SocketError.HostDown)) {
            // Connection failed, retry
            System.Threading.Thread.Sleep(1000);
          }
          else throw;
        }
      }
    }
