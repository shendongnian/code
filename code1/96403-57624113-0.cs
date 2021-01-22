    public static void DoRetry(
        List<Type> retryOnExceptionTypes,
        Action actionToTry,
        int retryCount = 5,
        int msWaitBeforeEachRety = 300)
    {
        for (var i = 0; i < retryCount; ++i)
        {
            try
            {
                actionToTry();
                break;
            }
            catch (Exception ex)
            {
                // Retries exceeded
                // Throws on last iteration of loop
                if (i == retryCount - 1) throw;
                // Is type retryable?
                var exceptionType = ex.GetType();
                if (!retryOnExceptionTypes.Contains(exceptionType))
                {
                    throw;
                }
                
                // Wait before retry
                Thread.Sleep(msWaitBeforeEachRety);
            }
        }
    }
    public static void DoRetry(
        Type retryOnExceptionType,
        Action actionToTry,
        int retryCount = 5,
        int msWaitBeforeEachRety = 300)
            => DoRetry(new List<Type> {retryOnExceptionType}, actionToTry, retryCount, msWaitBeforeEachRety);
