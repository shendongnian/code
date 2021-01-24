    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
        if (keyData == Keys.F1) { Application.Exit(); return true; }
        if (keyData == Keys.F2)
        {
            if (AddUrlIfNotExist("linkx.txt", webBrowser1.Url.AbsoluteUri))
            {
                MessageBox.Show("url copied!");
            }
            else
            {
                MessageBox.Show("there is a match");
            }
        }
        // Call the base class
        return base.ProcessCmdKey(ref msg, keyData);
    }
