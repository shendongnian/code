    var task = Task.Run(() =>
    {
        Task.Delay(10000).Wait();
    });
    bool terminate = false;
    while (!task.GetAwaiter().IsCompleted && !terminate)
    {
        // do something 
        if (task.GetAwaiter().IsCompleted) break;
        // do something heavy
        if (task.GetAwaiter().IsCompleted) break;
        // do another heavy operation
        for (int i = 0; i < 10000; i++)
        {
            // it took too long!
            if (i == 1000)
            {
                terminate = true;
                break;
            }
        }
    }
