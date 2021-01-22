    public static async Task<bool> TryDeleteDirectory(
       string directoryPath,
       int maxRetries = 10,
       int millisecondsDelay = 30)
    {
        if (directoryPath == null)
            throw new ArgumentNullException(directoryPath);
        if (maxRetries < 1)
            throw new ArgumentOutOfRangeException(nameof(maxRetries));
        if (millisecondsDelay < 1)
            throw new ArgumentOutOfRangeException(nameof(millisecondsDelay));
        for (int i = 0; i < maxRetries; ++i)
        {
            try
            {
                if (Directory.Exists(directoryPath))
                {
                    Directory.Delete(directoryPath, true);
                }
                return true;
            }
            catch (IOException)
            {
                await Task.Delay(millisecondsDelay);
            }
            catch (UnauthorizedAccessException)
            {
                await Task.Delay(millisecondsDelay);
            }
        }
        return false;
    }
