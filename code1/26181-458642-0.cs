    bool retries = 0;
    while (retries < MAX_RETRIES)
    {
        try
        {
            ... database access code
            break;
        }
        // If under max retries, log and increment, otherwise rethrow
        catch (SqlException e)
        {
            logger.LogWarning(e);
            if (++retries >= MAX_RETRIES)
            {
                throw new MaxRetriesException(MAX_RETRIES, e);
            }
        }
        // Can't retry.  Log error and rethrow.
        catch (ApplicationException e)
        {
            logger.LogError(e);
            throw;
        }
    }
