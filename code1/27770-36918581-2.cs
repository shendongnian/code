    private void bgwRun_DoWork(object sender, DoWorkEventArgs e)
    {
      while (!bgwRun.CancellationPending)
      {
       //build TPL Tasks
       var tasks = new List<Task>();
      
       //work to add tasks here
     
       tasks.Add(new Task(()=>{
        
         //build .Net ProcessInfo, Process and start Process here
        
         ThreadPool.QueueUserWorkItem(state =>
           {
               while (!process.StandardOutput.EndOfStream)
               {
                   var output = process.StandardOutput.ReadLine();
                   if (!string.IsNullOrEmpty(output))
                   {
                       bgwRun_ProgressChanged(this, new ProgressChangedEventArgs(0, new ExecutionInfo
                       {
                           Type = "ExecutionInfo",
                           Text = output,
                           Configuration = s3SyncConfiguration
                       }));
                   }
                   if (cancellationToken.GetValueOrDefault().IsCancellationRequested)
                   {
                         break;
                   }
               }
           });
       });//work Task
       //loop through and start tasks here and handle completed tasks
      } //end while
    }
