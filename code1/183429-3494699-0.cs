        BackgroundWorker bgw;
        private void button1_Click(object sender, EventArgs e)
        {
            bgw = new BackgroundWorker();
            bgw.DoWork += new DoWorkEventHandler(bgw_DoWork);
            bgw.WorkerReportsProgress = true;
            bgw.ProgressChanged += new ProgressChangedEventHandler(bgw_ProgressChanged);
            bgw.RunWorkerAsync(bgw);
        }
        void bgw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            var exception = e.UserState as Exception;
            if( exception != null )
                textBox1.Text = exception.Message;
        }
        void bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            var bgw = sender as BackgroundWorker;
            try
            {
                throw new NotImplementedException();
            }
            catch ( Exception exception )
            {
                bgw.ReportProgress(100, exception);
            }
        }
