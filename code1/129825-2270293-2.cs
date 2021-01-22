    static void TryExecute<TException>(Action method, Func<TException, bool> retryFilter, int maxRetries) where TException : Exception {
        try {
            method();
        } catch(TException ex) {
            if (maxRetries > 0 && retryFilter(ex))
                TryExecute(method, retryFilter, maxRetries - 1);
            else
                throw;
        }
    }
