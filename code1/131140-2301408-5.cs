    public void SetStatus(string msg)
    {
        if (lblStatus.InvokeRequired)
            lblStatus.Invoke(new MethodInvoker(delegate
            {
                lblStatus.Text = msg;
            }));
        else
            lblStatus.Text = msg;
    }
