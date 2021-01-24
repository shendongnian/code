    public static bool CheckWithTimeout(Func<bool> toBeChecked, int msToWait)
    {
        //var src = CancellationSource
        var task = Task.Run(()=> {
            while (!toBeChecked())
            {
                System.Threading.Thread.Sleep(25);
            }                    
        });
        if (task.Wait(TimeSpan.FromMilliseconds(msToWait)))
            return toBeChecked();
        else
            return false;
    }
