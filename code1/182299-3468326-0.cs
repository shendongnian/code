    private TaskScheduler ui;
    private void button1_Click(object sender, EventArgs e) 
    {
        ui = TaskScheduler.FromCurrentSynchronizationContext();
        DateTime start = DateTime.Now;
        Task.Factory.StartNew(pforeach)
            .ContinueWith(task =>
            {
                task.Wait(); // Ensure errors are propogated to the UI thread.
                Text = (DateTime.Now - start).ToString(); 
            }, ui);
    } 
 
    private void pforeach() 
    { 
        int[] intArray = new int[60]; 
        int totalcount = intArray.Length; 
        object lck = new object(); 
        System.Threading.Tasks.Parallel.ForEach<int, int>(intArray, 
        () => 0, 
        (x, loop, count) => 
        { 
            int value = 0; 
            System.Threading.Thread.Sleep(100); 
            count++; 
            value = (int)(100f / (float)totalcount * (float)count); 
 
            Task.Factory.StartNew(
                () => Set(value),
                CancellationToken.None,
                TaskCreationOptions.None,
                ui).Wait();
            return count; 
        }, 
        (x) => 
        { 
     
        }); 
    } 
 
    private void Set(int i) 
    { 
        progressBar1.Value = i; 
    } 
