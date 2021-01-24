    try
    {
        await Task.Run(() => Execute(action));
        Continuation();    
    }
    catch(Exception e)
    {
        LogExceptions(e)
    }
    finally
    {
        CustomLogging();
    }
