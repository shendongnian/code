    private void tabControler_Selecting(object sender, TabControlCancelEventArgs e)
    {
        if (!e.TabPage.Enabled)
        {
            e.Cancel = true;
        }
    }
