    private async void button1_Click(object sender, EventArgs e)
    {
        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        List<Task<string>> tasks = new List<Task<string>>();
        tasks.Add(Task.Run<string>(() => // run your tasks
           {
               while (true)
               {
                   if (cancellationTokenSource.IsCancellationRequested)
                   {
                       return null;
                   }
                   return "Result";  //string or null
               }
           }));
        while (tasks.Count > 0)
        {
            Task<string> resultTask = await Task.WhenAny(tasks);
            string result = await resultTask;
            if (result == null)
            {
                tasks.Remove(resultTask);
            }
            else
            {
                // success
                cancellationTokenSource.Cancel(); // will cancel all tasks
            }
        }
    }
