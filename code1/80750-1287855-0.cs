    public void Dispose()
    {
        if (handler != null)
        {
            handler.Load -= Load;
            handler.Close -= Close;
        }
    }
