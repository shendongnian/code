    private void SetStatus(string status) 
    {
        lblStatus.Text = status;
        lblStatus.Invalidate();
        lblStatus.Update();
        lblStatus.Refresh();
        Application.DoEvents();
    }
