    var asyncResult = command.BeginExecute();
    while (!asyncResult.IsCompleted)
    {
        if (command.State != OldState)
        {
            progress.Report(newState);
        }
        // Key piece in this polling loop.
        await Dispatcher.Yield(DispatcherPriority.ApplicationIdle);
    }
    command.EndExecute(asyncResult);
