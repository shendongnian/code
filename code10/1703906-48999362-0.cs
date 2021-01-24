    // note the *async* here; async main methods are supported with C# 7.1
    public static async void Main(string[] args)
    {
        var run = TaskRunner();
        // await the task
        await run;
        if (run.IsCompleted)
        {
            Debug.WriteLine("this worked!");
        }
        else
        {
            Debug.WriteLine("this failed!");
        }
    }
