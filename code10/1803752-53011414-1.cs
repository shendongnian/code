    int processCount = 5; // or whatever
    Task[] tasks = new Task[processCount];
    for(int i = 0; i < processCount; i++)
    {
      Task t = new Task(() => {
        ProcessStartInfo psi = ...
        // start your process here
        process.WaitForExit();
        if (pr.ExitCode == 0)
        {
            //write status to a file the xml status
            // remember to synchronize writes to the file so multiple tasks
            // don't try to open the same file at the same time
            // or just use different file names for each process
        }
      });
      t.Start();
      tasks[i] = t;
    }
    Task.WaitAll(tasks);
    // continue with rest of program
