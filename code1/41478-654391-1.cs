    RandomType variable = new RandomType(1,2,3);
    try
    {
        // A bunch of code
    }
    finally
    {
        if(variable is IDisposable)
            (variable as IDisposable).Dispose()
    }
