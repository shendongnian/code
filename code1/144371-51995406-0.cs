    static public T ExecuteRetryable<T>(
        Func<T> function,
        out int actualAttempts,
        string actionDescriptionForException = "SQL",
        int maxTries = 3,
        int pauseMaxMillis = 1000,
        bool alsoPauseBeforeFirstAttempt = false,
        bool allowRetryOnTimeout = false)
    {
        Exception mostRecentException = null;
    
        for (int i = 0; i < maxTries; i++)
        {
            // Pause at the beginning of the loop rather than end to catch the case when many servers
            // start due to inrush of requests (likely).  Use a random factor to try and avoid deadlock 
            // in the first place.
            //
            if (i > 0 || alsoPauseBeforeFirstAttempt)
                Thread.Sleep(new Random
                (
                    // Default Initializer was just based on time, help the random to differ when called at same instant in different threads.
                    (Int32)((DateTime.Now.Ticks + Thread.CurrentThread.GetHashCode() + Thread.CurrentThread.ManagedThreadId) % Int32.MaxValue)
                )
                .Next(0, pauseMaxMillis));
    
            actualAttempts = i + 1;
    
            try
            {
                T returnValue = function();
                return returnValue;
            }
            catch (Exception ex)
            {
                // The exception hierarchy may not be consistent so search all inner exceptions.
                // Currently it is DbUpdateException -> UpdateException -> SqlException 
                //
                if (!SqlExceptionUtil.IsSqlServerErrorType(ex, SqlServerErrorType.Deadlock) &&                    
                    (!allowRetryOnTimeout || !SqlExceptionUtil.IsSqlServerErrorType(ex, SqlServerErrorType.Timeout)))
                    throw;
    
                mostRecentException = ex;
            }
        }
    
        throw new Exception(
            "Unable to perform action '" + actionDescriptionForException + "' after " + maxTries +
            " tries with pauses of [0," + pauseMaxMillis + "]ms due to multiple exceptions.",
            mostRecentException);
    }
