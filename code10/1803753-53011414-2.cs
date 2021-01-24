    int processCount = 5; // or whatever
    Task[] tasks = new Task[processCount];
    for(int i = 0; i < processCount; i++)
    {
      TaskCompletionSource<int> taskCompletionSource = new TaskCompletionSource<int>();
      ProcessStartInfo psi = new ProcessStartInfo();
      var process = new Process();
      process.StartInfo = psi;
      process.Exited += (obj, args) =>
      {
        // write to file here
        taskCompletionSource.SetResult(process.ExitCode);
      };
      process.Start();
      tasks[i] = taskCompletionSource.Task;
    }
