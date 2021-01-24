    public async Task WaitForAllSubmittedTasks()
    {
        // Work is being submitted in a background thread;
        // Wrap that thread in a Task, and wait for it to complete.
        var workScheduler = GetWorkScheduler();
        await workScheduler;
        // All tasks submitted!
        // Now we get the completed list of all submitted tasks.
        // It's important to note: the submitted tasks
        // have been chugging along all this time.
        //
        // By the time we get here, there are probably a number of
        // completed tasks already.  There is no downside to this approach.
        var submittedWork = GetAllSubmittedTasks();
        await Task.WhenAll(submittedWork);
        // Work complete!
    }
