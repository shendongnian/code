    MyMethodResult result = null;
    Exception retryException = null;
    for (int retryAttempt = 1; retryAttempt <= Config.MaxRetryAttempts; retryAttempt++)
    {
        try
        {
            result = SomeWebService.MyMethod(myId);
            retryException = null;
            break;
        }
        catch (Exception ex)
        {
            retryException = ex;
            Logger.LogEvent(string.Format("Retry attempt #{0} for SomeWebService.MyMethod({1})", retryAttempt, myId);
            Thread.Sleep(retryAttempt * Config.RetrySleepSeconds * 1000);
        }
    }
    if (retryException != null)
    {
        Logger.LogError(string.Format("Max Retry Attempts Exceeded for SomeWebService.MyMethod({0})", MyId), ex);
        throw new Exception(string.Format("Max Retry Attempts Exceeded for SomeWebService.MyMethod({0})", myId), ex);
    }
