    ManualResetEvent signal = new ManualResetEvent(false);
    using (NamedPipeServerStream stream = ...)
    {
        var asyncResult = stream.BeginWaitForConnection(null, null);
        signal.WaitOne();
        if (asyncResult.IsCompleted)
        {
            stream.EndWaitForConnection(asyncResult);
            // success
        }
    }
    // in other thread
    void cancel_Click(object sender, EventArgs e)
    {
        signal.Set();
    }
