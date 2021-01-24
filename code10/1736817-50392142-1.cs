    try
    {
        ...
    }
    catch (Exception exc)
    {
        try
        {
            Logger.LogEntry(LogEntryModel.Create(this).Fatal("Dispatcher Catch"));
            ...etc...
        }
        catch
        {
        }
    }
