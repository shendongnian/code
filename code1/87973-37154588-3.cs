    private FileStream GetWriteStream(string path, int timeoutMs)
    {
        var time = Stopwatch.StartNew();
        while (time.ElapsedMilliseconds < timeoutMs)
        {
            try
            {
                return new FileStream(path, FileMode.Create, FileAccess.Write);
            }
            catch (IOException e)
            {
                // access error
                if (e.HResult != -2147024864)
                    throw;
            }
        }
    
        throw new TimeoutException($"Failed to get a write handle to {path} within {timeoutMs}ms.");
    }
