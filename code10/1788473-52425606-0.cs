    private void button1_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy != true)
            {
                backgroundWorker1.RunWorkerAsync();
            }
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            String errMsg = parseString();
            if (errMsg == "")
            {
                if (listBox1.InvokeRequired)
                {
                    listBox1.Invoke(new MethodInvoker(delegate
                    {
                        listBox1.Items.Clear();
                        listBox1.Show();
                    }));
                }
                if (progressBar1.InvokeRequired)
                {
                    progressBar1.Invoke(new MethodInvoker(delegate
                    {
                        progressBar1.Maximum = 100;
                        progressBar1.Step = 1;
                        progressBar1.Value = 0;
                        progressBar1.Show();
                    }));
                }
                if (backgroundWorker2.IsBusy != true)
                {
                    backgroundWorker2.RunWorkerAsync();
                }
            }
            else
            {
                MessageBox.Show(errMsg);
            }
        }
        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            backgroundWorker2.ReportProgress(1, "Updating Devices");
            for (int i = 0; i < 100; i++)
            {
                System.Threading.Thread.Sleep(3000);
                //do stuff
                backgroundWorker2.ReportProgress(i, "Device:" + i);
            }
        }
        private void backgroundWorker2_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (progressBar1.InvokeRequired)
            {
                progressBar1.Invoke(new MethodInvoker(delegate
                {
                    progressBar1.Value = e.ProgressPercentage;
                }));
            }
            if (listBox1.InvokeRequired)
            {
                listBox1.Invoke(new MethodInvoker(delegate
                {
                    listBox1.Items.Add(e.UserState);
                }));
            }
        }
        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            MessageBox.Show("DONE");
        }
