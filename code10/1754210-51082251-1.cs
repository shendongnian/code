    Task<string> ShellAsync(string commandPath,string argument)
    {
        var tcs = new TaskCompletionSource<string>();
        var process = new Process();
        //Configure the process
        //...
        process.EnableRaisingEvents = true;
        process.Exited += (s,e) => tcs.TrySetResult("OK");
        process.Start();
        return tcs.Task;
    }
    
