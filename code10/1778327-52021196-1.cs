    public async Task Caller()
    {
        var (partOne,partTwo) = DoSomethingAsync();
        
        await partOne;
        //part one is done...
        
        await partTwo;
        //part two is done...
    }
    public (Task,Task) DoSomethingAsync()
    {
        var tcs = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
        return (tcs.Task, DoWork(tcs));
    }
    public async Task DoWork(TaskCompletionSource<bool> tcs)
    {
        List<MyObject> objList = GetObjects();
        int counter = 0;
        await Task.Run(() =>
        {
            foreach (MyObject obj in objList)
            {
                counter++;
                CallExtWebSvc(obj);
                if (counter == 1)
                {
                    // return an indication that main process can proceed.
                    tcs.SetResult(true);
                }
            }
        });
        // Do other stuff...
    }
 
