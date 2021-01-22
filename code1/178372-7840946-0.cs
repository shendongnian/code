     public class ContentManagerTask
    {
        public ContentManagerTask(DownloadResult downloadResult)
        {
            TaskResult = downloadResult;
            this.BeginTask(downloadResult);
        }
        public DownloadResult TaskResult;
        /// <summary>Starts a background task to compute a value and returns immediately.</summary>
        private void BeginTask(DownloadResult downloadResult)
        {
            downloadResult.Result = false;
            Task task = new Task(() =>
            {
                var result = Download(downloadResult);
                lock (this)
                {
                    TaskResult = result;
                }
            });
            task.Start();
        }
        private DownloadResult Download(DownloadResult downloadResult)
        {
            try
            {
                // Logic to download file
                int i = 0;
                while (i < 10)
                {
                    Thread.Sleep(10000);
                    i++;
                    string log = string.Format("Content Manager: Task - {4} - (Time {0}; ID: {1}) is downloading this File: '{2}' from URL: '{3}' ", DateTime.Now.ToString(), downloadResult.ContentItem.ID, downloadResult.ContentItem.FileName, downloadResult.ContentItem.URL, i.ToString());
                    CustomLogger.CustomLogger.WriteNormalLog(log); 
                }
                downloadResult.Result = true;
            }
            catch (Exception ex)
            {
                #region Error
                LogEntry l = new LogEntry();
                l.Message = string.Format("Error: {0}", ex.Message);
                l.Title = "MyApp Error";
                l.Categories.Add(Category.General);
                l.Priority = Priority.Highest;
                l.ExtendedProperties.Add("Method", "DownloadError Download()");
                if (ex.InnerException != null) l.ExtendedProperties.Add("InnerException", ex.InnerException.Message);
                CustomLogger.CustomLogger.WriteErrorLog(l);
                #endregion
                downloadResult.Error = ex;
            }
            return downloadResult;
        }
    }
