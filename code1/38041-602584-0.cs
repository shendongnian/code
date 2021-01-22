        private void btnBrowse_Click(object sender,EventArgs e)
        {
            StripProgressBar.Value = 0;
            toolStripStatusLabel1.Text = "Browsing for a  Xml file";
            if (open.ShowDialog(this) == DialogResult.OK)
            {
                txtFileName.Text = open.FileName;
                initiatingTree(open.FileName); 
                bgWorker1.RunWorkerAsync();
                while (this.bgWorker1.IsBusy)
                {
                    StripProgressBar.Increment(1);
                    // Keep UI messages moving, so the form remains
                    // responsive during the asynchronous operation.
                    Application.DoEvents();
                }
            }
        }
