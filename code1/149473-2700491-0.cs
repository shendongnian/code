    using (NamedPipeServerStream stream = ...)
    {
        var asyncResult = stream.BeginWaitForConnection(null, null);
        if (asyncResult.AsyncWaitHandle.WaitOne(5000))
        {
            stream.EndWaitForConnection(asyncResult);
            // success
        }
    }
