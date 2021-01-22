    using (var sta = new StaTaskScheduler(1))
    {    
        var taskResult = await Task.Factory.StartNew(() =>
        {
            var results = new List<ResultType>();
            using (var ax = new MyActiveXType())
            {
                // important to call this just after constructing ActiveX type
                ax.CreateControl();
                ax.SomeIterativeEvent += (s, e) => results.Add(e.SomeThing);
    
                // if applicable, you can tear down the message pump
                ax.SomeFinalEvent += (s, e) => Application.ExitThread();
    
                //more initialize work
                // start message pump
                Application.Run();
                return results;
            }
        }, CancellationToken.None, TaskCreationOptions.None, sta);
    
        return taskResult;
    }
