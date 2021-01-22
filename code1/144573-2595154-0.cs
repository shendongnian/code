    var asyncResult = pipeServer.BeginWaitForConnection(PipeConnected, this);
    if (asyncResult.AsyncWaitHandle.WaitOne(5000))
    {
        pipeServer.EndWaitForConnection(asyncResult);
        // ...
    }
