            var stopwatch = new Stopwatch();
            stopwatch.Start();
            var taskList = new List<Task>();
            taskList.Add(Task.Run(()=> DoWork()));
            taskList.Add(Task.Run(() => DoWork()));
            taskList.Add(Task.Run(() => DoWork()));
            taskList.Add(Task.Run(() => DoWork()));
            taskList.Add(Task.Run(() => DoWork()));
            taskList.Add(Task.Run(() => DoWork()));
            taskList.Add(Task.Run(() => DoWork()));
            taskList.Add(Task.Run(() => DoWork()));
            await Task.Run(()=>Task.WaitAll(taskList.ToArray()));
            stopwatch.Stop();
            var timeRan = stopwatch.Elapsed.Seconds;
            //log time
