    void IDisposable.Dispose()
    {
        bool success = false;
        try 
        {
            if (State != CommunicationState.Faulted) 
            {
                Close();
                success = true;
            }
        } 
        finally 
        {
            if (!success) 
                Abort();
        }
    }
