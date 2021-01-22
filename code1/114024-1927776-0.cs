            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.DoWork += (newSender, newE) =>
            {
                while (!this.ourCC.Connected)
                {
                    this.ourCC.InitializeConnection();
                    if (!this.ourCC.Connected)
                    {
                        backgroundWorker.ReportProgress(0, true);
                    }
                }
            };
            backgroundWorker.ProgressChanged += (newSender, newE) =>
            {
                if (!ourECF.Visible)
                {
                    ourECF.Show();
                }
            };
            backgroundWorker.RunWorkerCompleted += (newSender, newE) =>
            {
                ourECF.Dispose();
            };
            backgroundWorker.RunWorkerAsync();
