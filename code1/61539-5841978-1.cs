      private volatile bool _isDisposed = false;
      /**
      * _isDisposed stops the two "partners" in the conversation (us and 
      * Internet Explorer) from going into "infinite recursion", by calling 
      * each others Dispose methods within there Dispose methods.
      *
      * NOTE: I **think** that making _isDisposed volatile deals adequately
      * with the inherent race condition, but I'm NOT certain! Comments
      * welcome on this one.
      */
      public void Dispose() {
        if (!_isDisposed) {
          _isDisposed = true;
          try {
            try { release my unmanaged resources } catch { log }
            try {
              IE calls MyApp.Dispose() here // and FALLOUT on failure
              MyApp calls IE.Dispose(); here
            } catch {
              log
            }
          } finally {
            base.Dispose(); // ALLWAYS dispose base, no matter what!
          }
        }
      }
