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
                       Thread.CurrentThread.Abort(state);
                   }
               }
           });
