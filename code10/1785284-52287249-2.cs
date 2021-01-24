    // MODIFY while contition.
    while (!_TokenSource.IsCancellationRequested)
    {  
        // Set the event to nonsignaled state.  
        allDone.Reset();  
        listener.BeginAccept(new AsyncCallback(AcceptCallback), listener);
        // Wait until a connection is made before continuing.  
        allDone.WaitOne();  
    }  
