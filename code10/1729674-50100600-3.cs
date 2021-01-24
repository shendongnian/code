             var stopwatch = new Stopwatch();
            stopwatch.Start();
            Action<string> logTime = (label) => Console.WriteLine($"{label}: {stopwatch.Elapsed.Seconds} in Seconds");
            var taskList = new List<Task>();
            taskList.Add(Task.Run(() => { DoWork(); logTime("Task 1");}));
            taskList.Add(Task.Run(() => { DoWork(); logTime("Task 2"); }));
            taskList.Add(Task.Run(() => { DoWork(); logTime("Task 3"); }));
            taskList.Add(Task.Run(() => { DoWork(); logTime("Task 4"); }));
            taskList.Add(Task.Run(() => { DoWork(); logTime("Task 5"); }));
            taskList.Add(Task.Run(() => { DoWork(); logTime("Task 6"); }));
            taskList.Add(Task.Run(() => { DoWork(); logTime("Task 7"); }));
            taskList.Add(Task.Run(() => { DoWork(); logTime("Task 8"); }));
            Task.WaitAll(taskList.ToArray());
            stopwatch.Stop();
            var timeRan = stopwatch.Elapsed.Seconds;
            //log time
            logTime("Total Time");
            Console.ReadLine();
