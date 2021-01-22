        private void buttonRun_Click(object sender, EventArgs e)
        {
            if (comboBoxFiscalYear.SelectedIndex != -1 && !string.IsNullOrEmpty(textBoxFolderLoc.Text))
            {
                try
                {
                    u = new UpdateDispositionReports(
                        Convert.ToInt32(comboBoxFiscalYear.SelectedItem.ToString())
                        , textBoxFolderLoc.Text
                        , Properties.Settings.Default.TemplatePath
                        , Properties.Settings.Default.ConnStr);
                    this.buttonRun.Enabled = false;
                    this.pictureBox1.Visible = true;
                    BackgroundWorker bw = new BackgroundWorker();
                    bw.DoWork += new DoWorkEventHandler(bw_DoWork);
                    bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bw_RunWorkerCompleted);
                    bw.RunWorkerAsync();
                    //backgroundWorker1.RunWorkerAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unable to process.\nError:" + ex.Message, Properties.Settings.Default.AppName);
                }
            }
        }
        delegate void ReenableRunCallback();
        private void ReenableRun()
        {
            if (this.buttonRun.InvokeRequired)
            {
                ReenableRunCallback r = new ReenableRunCallback(ReenableRun);
                this.buttonRun.Invoke(r, null);
            }
            else
                this.buttonRun.Enabled = true;
        }
        private void HideProgress()
        {
            if (this.pictureBox1.InvokeRequired)
            {
                ReenableRunCallback r = new ReenableRunCallback(HideProgress);
                this.pictureBox1.Invoke(r, null);
            }
            else
                this.pictureBox1.Visible = false;
        }
        void bw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            ReenableRun();
            HideProgress();
        }
        void bw_DoWork(object sender, DoWorkEventArgs e)
        {
            u.Execute();
        }
