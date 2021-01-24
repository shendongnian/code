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
        // By the time we get here, there are probably a number of
        // completed tasks already.  It does not delay the speed
        // or execution of our work items if we grab the List
        // after some of the work has been completed.
        //
        // It's entirely possible that - by the time we call
        // this function and wait on it - almost all the 
        // tasks have already been completed!
        var submittedWork = GetAllSubmittedTasks();
        await Task.WaitAll(submittedWork);
        // Work complete!
    }
