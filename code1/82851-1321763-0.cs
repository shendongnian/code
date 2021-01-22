        private void button1_Click(object sender, EventArgs e)
        {
            progressBar1.Maximum = 100;
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.ProgressChanged += new ProgressChangedEventHandler(backgroundWorker1_ProgressChanged);
            backgroundWorker1.DoWork += new DoWorkEventHandler(backgroundWorker1_DoWork);
            backgroundWorker1.RunWorkerCompleted += new RunWorkerCompletedEventHandler(backgroundWorker1_RunWorkerCompleted);
            backgroundWorker1.RunWorkerAsync();
        }
 
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            // This would be the load process, where you put your Load methods into.
            // You would report progress as something loads.
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(100);
                backgroundWorker1.ReportProgress(i); //run in back thread
            }
        }
 
        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e) //call back method
        {
            progressBar1.Value = e.ProgressPercentage;
        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) //call back method
        {
            progressBar1.Value = progressBar1.Maximum;
        }
