    //Make a cancellation token source to signal other tasks to cancel.
    CancellationTokenSource cts = new CancellationTokenSource();
    for (int i = 0; i < tasks.Length; i++)
    {
        tasks[i] = Task.Run(() => {
            while (!cts.IsCancellationRequested) //Monitor for the cancellation token source to signal canceled.
            {
                if (retries >= maximumRetries || finished > 0)
                    return Maybe<T>.Empty;
    
                var attempt = func();
                if (attempt.ContainsValue)
                {
                    Interlocked.Increment(ref finished);
                    return attempt;
                }
                else
                {
                    Interlocked.Increment(ref retries);
                }
            }
            return Maybe<T>.Empty;
        }, cts.Token); //Add the token to the task.
    }
    
    var completedTaskIndex = Task.WaitAny(tasks); //Task.WaitAny gives you the index of the Task that did complete.
    cts.Cancel(); //Signal the remaining tasks to complete.
    var completedTask = tasks[completedTaskIndex]; //Get the task that completed.
    return completedTask.Result; //You're returning Maybe<T>.Emtpy from the Task if it fails so no need to check ContainsValue; just return the result.
