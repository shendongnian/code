    protected override bool ProcessDialogKey(Keys keyData)
    {
        if (keyData == Keys.Enter)
        {
            if (panel1.ContainsFocus)
            {
                button1.PerformClick();
                return true;
            }
            if (panel2.ContainsFocus)
            {
                button2.PerformClick();
                return true;
            }
        }
        return base.ProcessDialogKey(keyData);
    }
