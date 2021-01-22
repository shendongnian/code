    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
        // If it wasn't the user who asked for the closing, we just close
        if (e.CloseReason != CloseReason.UserClosing)
            return;
        // If it was the user, we want to make sure he didn't do it by accident
        DialogResult r = MessageBox.Show("Are you sure you want this?", 
                                         "Application is shutting down.",
                                         MessageBoxButtons.YesNo, 
                                         MessageBoxIcon.Question);
        if (r != DialogResult.Yes)
        {
            e.Cancel = true;
            return;
        }
    }
    protected override void OnFormClosed(FormClosedEventArgs e)
    {
        // Start the task
        var thread = new Thread(DoTask)
        {
            IsBackground = false,
            Name = "Closing thread.",
        };
        thread.Start();
        base.OnFormClosed(e);
    }
    private void DoTask()
    {
        // Some task to do here
    }
