    Thread thread = new Thread(delegate() {
        try
        {
            MyIPoller.Start();
        }
        catch(ThreadAbortException)
        {
        }
        catch(Exception ex)
        {
            //handle
        }
        finally
        {
        }
    });
