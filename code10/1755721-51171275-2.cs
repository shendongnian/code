    instanceOfWinRTObject.OnSuspendingEvent += async (sender, args) =>
    {
        var deferral = args.Deferral;
        try
        {
            // Client does some async work with a result
            args.Result = await GetSomeStringAsync(args);
        }
        finally
        {
            deferral.Complete();
        }
    }
