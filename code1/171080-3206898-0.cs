    private readonly Queue<Exception> _exceptions = new Queue<Exception>();
    private void DoWork(object o)
    {
        try
        {
            // ...
        }
        catch (Exception ex)
        {
            _exceptions.Enqueue(ex);
        }
        finally
        {
            done.Set();
        }
    }
