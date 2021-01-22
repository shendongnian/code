      private bool isDisposed = false;
      public void Dispose() {
        if (!isDisposed) {
          isDisposed = true;
          try {
            try { release my unmanaged resources } catch { log }
            // the isDisposed attribute prevents infinite recursion between the two calls
            try {
              IE calls MyApp.Dispose() here
              MyApp calls IE.Dispose(); here
            } catch {
              log
            }
          } finally {
            base.Dispose();
          }
        }
      }
