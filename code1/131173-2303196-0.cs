    private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
            {
                MessageBox.Show(e.UserState.ToString());
            }
    
            private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
            {
                try
                {
                    //some code that throws an exception
                    throw new NotImplementedException();
                }
                catch (Exception ex) 
                {
                    backgroundWorker1.ReportProgress(0/*percent of progress*/, ex);
                 
                }
            }
            private void Form1_Load(object sender, EventArgs e)
            {
                backgroundWorker1.RunWorkerAsync();
            }
