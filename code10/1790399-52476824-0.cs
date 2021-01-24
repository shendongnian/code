    public async Task RetryExecuteAsync(Func<Task> action)
    {
        int retryCount = default(int);
        int maxNumberOfRetries = 5; // Or get from settings
    
        while (true)
        {
            try
            {
                await action().ConfigureAwait(false);
    
                break;
            }
            catch (ArgumentNullException)
            {
                // Something specific about this exception
                if (++retryCount > maxNumberOfRetries)
                    throw;
            }
            catch (Exception)
            { 
                if (++retryCount > maxNumberOfRetries)
                    throw;
            }
        }
    }
