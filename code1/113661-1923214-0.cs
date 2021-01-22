    private void updateStatusBar(string status)
    {
        StatusLabel.Invoke((MethodInvoker)(() =>
                    {
                        StatusLabel.Text = status;
                    }));
     
    }
