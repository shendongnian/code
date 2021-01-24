    var readyTask = await Task.WhenAny(myLongRunningTask, Task.Delay(9000)).ConfigureAwait(false);
    if (readyTask != myLongRunnnigTask && !myLongRunningTask.IsFaulted)
    {
        Console.WriteLine("TimedOut");
    }
    else
    {
        Console.WriteLine("Completed");
    }
