    [DllImport("ole32.dll")]
    private static extern void CoFreeUnusedLibraries();
    private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
    {
        base.OnFormClosed(e);
        webBrowser1.Visible = false;
        while (webBrowser1.IsBusy)
        {
            Application.DoEvents();
        }
        webBrowser1.Dispose();
        CoFreeUnusedLibraries();
    }
