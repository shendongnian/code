         for (int i = 0; i < found.Count; i++)
         {
             int progress = (int)((i / found.Count) * 100);
             if (found[i].Contains("SFTP:") || found[i].Contains("ERROR:"))
             {
                 result.Add(item);
    
                 (sender as BackgroundWorker).ReportProgress(progress, item);
             }
             else
                 (sender as BackgroundWorker).ReportProgress(progress);
             System.Threading.Thread.Sleep(1000);    
         }
