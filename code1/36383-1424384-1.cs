    void IDisposable.Dispose()
    {
        bool success = false;
        try {
            if (State != CommunicationState.Faulted) {
                Close();
                success = true;
            }
        } finally {
            if (!success) {
                try {
                Abort();
                }
                catch (Exception){
                // Abort can throw an exception, nothing to do but swallow it.
                }
            }
        }
    }
