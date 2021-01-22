    private void SendLoop() {
      do {
        if ( _sockets.Count > 0 ) {
        } else { 
          System.Threading.Thread.Sleep(10);
        }
        bool shouldContinue;
        lock ( runLock ) { 
          shouldContinue = _IsRunning;
        }
      while(shouldContinue);
    }
