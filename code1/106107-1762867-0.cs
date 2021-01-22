      #region Background Worker
        void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.TaskbarItemInfo.ProgressValue = (double)e.ProgressPercentage / 100;
            
        }
        void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                this.TaskbarItemInfo.ProgressState = TaskbarItemProgressState.Paused;
            }
            else if (e.Error != null)
            {
                this.TaskbarItemInfo.ProgressState = TaskbarItemProgressState.Error;
            }
            else
            {
                this.TaskbarItemInfo.ProgressState = TaskbarItemProgressState.None;
            }
        }
        void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 1; i <= 100; i++)
            {
                Thread.Sleep(100);
                
                this.backgroundWorker1.ReportProgress(i,i.ToString());
            }
                }
            }
        }
        #endregion
