    private static bool isStarted = false;
    private static object moduleStart = new Object();
    ...
    if (!isStarted)
    {
        lock(moduleStart)
        {
            if (!isStarted)
            {
                // handle aplication start
                ...
                isStarted = true;
            }
        }
    }
