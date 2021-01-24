     public void Dispose()
     {
          server.Dispose();
          GC.SuppressFinalize(this);
     }
     ~MultiplayerState() => Dispose()
