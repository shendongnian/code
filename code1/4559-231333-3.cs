    // Get configurable wait time
    TimeSpan waitTime = TimeSpan.FromSeconds(15.0);
    int configWaitTimeSec;
    if (int.TryParse(ConfigManager.AppSetting["DefaultWaitTime"], out configWaitTimeSec))
        waitTime = TimeSpan.FromSeconds(configWaitTimeSec);
    bool keyPressed = false;
    DateTime expireTime = DateTime.Now + waitTime;
    // Timer and key processor
    ConsoleKeyInfo cki;
    // EDIT: adding a missing ! below
    while (!keyPressed && (DateTime.Now < expireTime))
    {
        if (Console.KeyAvailable)
        {
            cki = Console.ReadKey(true);
            // TODO: Process key
            keyPressed = true;
        }
        Thread.Sleep(10);
    }
