    private object windowLock = new object();
    private void ShowWindowBlocking()
    {
        lock (windowLock)
        {
            var result = MessageBox.Show(
                "Retry the connection?",
                "Connection Failed",
                MessageBoxButtons.RetryCancel);
            if (result == DialogResult.Retry)
            {
                // Retry the connection
            }
        }
    }
