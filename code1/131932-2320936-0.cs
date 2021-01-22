    int maxRetry = 3;
    int x = 0;
    tryAgain:
    try
    {
        using (var fs = File.Open("file.txt", FileMode.Open, 
                                              FileAccess.Read, 
                                              FileShare.None))
        {
            // you have exclusive read here
        }
    }
    catch (IOException)
    {
        if (x++ > maxRetry)
            throw;
        Thread.Sleep(500);
        goto tryAgain;
    }
