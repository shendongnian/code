    void MyThreadProc()
    {
        try
        {
            //Do interesting things
        }
        catch ( ThreadAbortException e )
        {
            childThread.Abort();
        }
    }
