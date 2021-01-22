    {
        MyDisposableType foo = new MyDisposableType();
        try
        {
            foo.DoSomething();
        }
        finally
        {
            if (foo != null)
                ((IDisposable)foo).Dispose();
        }
    }
