    BackgroundWorker bw = new BackgroundWorker();
        private void button1_Click(object sender, EventArgs e)
        {
            bw.DoWork += new DoWorkEventHandler(bw_DoWork);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
            if (bw.IsBusy != true)
            {
                bw.RunWorkerAsync();
            }
        }
        private void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            //
            // Boring.... Do your long work
            //
            System.Threading.Thread.Sleep(20000);
        }
        private void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (this.InvokeRequired)
            {
                //Hide your form here
                this.Invoke(new MethodInvoker(delegate { this.Close(); }));
            }
        }
