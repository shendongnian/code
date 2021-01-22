    MyMethodResult result = null;
    for (int retryAttempt = 1; retryAttempt <= Config.MaxRetryAttempts; retryAttempt++)
    {
        try
        {
            result = SomeWebService.MyMethod(myId);
            break;
        }
        catch (Exception ex)
        {
            if (retryAttempt < Config.MaxRetryAttempts)
            {
                Logger.LogEvent(string.Format("Retry attempt #{0} for SomeWebService.MyMethod({1})", retryAttempt, myId);
                Thread.Sleep(retryAttempt * Config.RetrySleepSeconds * 1000);
            }
            else
            {
                Logger.LogError(string.Format("Max Retry Attempts Exceeded for SomeWebService.MyMethod({0})", MyId), ex);
                throw new Exception(string.Format("Max Retry Attempts Exceeded for SomeWebService.MyMethod({0})", myId), ex);
            }
        }
    }
