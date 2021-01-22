    const int MAX_RETRY = 3;
    public static void DoWork()
    {
        //Do Something
    }
    public static void DoWorkWithRetry()
    {
        var @try = 0;
    retry:
        try
        {
            DoWork();
        }
        catch (Exception)
        {
            @try++;
            if (@try < MAX_RETRY)
                goto retry;
            throw;
        }
    }
