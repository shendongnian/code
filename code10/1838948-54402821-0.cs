        private void bgworker_DoWork(object sender, DoWorkEventArgs e)
        {
            lines = File.ReadAllLines(@"txtPath.Text");
            
        }
        private void bgworker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            foreach (string line in lines)
            {
                this.txtText.Text += (line + "\r\n");
            }
        }
