    if (appNotRestarted == true)
    {
        appNotRestarted = false;
        Application.Restart();
        Application.ExitThread();
    }
