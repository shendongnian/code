    Stopwatch stopwatch = new Stopwatch();
    stopwatch.Start();
    
    Task[] tasks = new Task[50];
    for (int i = 0; i < 50; i++)
    {
        int iCopy = i;
        tasks[i] = Task.StartNew(() => {
            AddNumbers();
            Thread.Sleep(1000);
            Console.WriteLine((iCopy + 1).ToString());
        });
    } 
    Task.WaitAll(tasks);
