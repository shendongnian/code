     private delegate void UpdateStatusBoxDel(string status);
        private void UpdateStatusBox(string status)
        {
            listBoxStats.Items.Add(status);
            listBoxStats.SelectedIndex = listBoxStats.Items.Count - 1;
            labelSuccessful.Text = SuccessfulSubmits.ToString();
            labelFailed.Text = FailedSubmits.ToString();
        }
        private void UpdateStatusBoxAsync(string status)
        {
            if(!areWeStopping)
                this.BeginInvoke(new UpdateStatusBoxDel(UpdateStatusBox), status);
        }
