    try
    {
        DoSomethingWithDevice();
    }
    finally
    {
        try
        {
            LockDevice();
        }
        catch (...)
        {
            ...
        }
    }
