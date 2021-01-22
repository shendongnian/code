    private void tcExemple_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (!((Control)e.TabPage).Enabled)
            {
                e.Cancel = true;
            }
        }
