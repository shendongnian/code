    var isAlreadyRegistered = BackgroundTaskRegistration.AllTasks.Any(t => t.Value?.Name == "BackroundTask");
    if (isAlreadyRegistered)
    {
        foreach (var tsk in BackgroundTaskRegistration.AllTasks)
        {
            if (tsk.Value.Name == "BackroundTask")
            {
                tsk.Value.Unregister(true);
                break;
            }
        }
    }
