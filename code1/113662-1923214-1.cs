    private void updateStatusBar(string status)
    {
        if (StatusLabel.InvokeRequired)
        {
            StatusLabel.Invoke((MethodInvoker)(() =>
                       {
                           StatusLabel.Text = status;
                       }));
        }
        else
        {
             StatusLabel.Text = status;
        }
    }
