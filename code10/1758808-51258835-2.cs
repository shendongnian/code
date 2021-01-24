    private void CreateOrUpdate(string msg = "Ready")
    {
        var statusBar = panel1.Controls.OfType<StatusBar>().FirstOrDefault();
        if (statusBar == null)
        {
            panel1.Controls.Add(new StatusBar { Text = msg });
        }
        else
        {
            statusBar.Text = msg;
        }
    }
