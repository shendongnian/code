    public void execPrint(String url)
    {
        System.Windows.Forms.WebBrowser ie = new System.Windows.Forms.WebBrowser();
        this.Controls.Add(ie);
        ie.ScriptErrorsSuppressed = true;
        ie.DocumentCompleted += Ie_DocumentCompleted;
        ie.Navigate(url);
        ie.Visible = false;
    }
    
    private void Ie_DocumentCompleted(object sender, System.Windows.Forms.WebBrowserDocumentCompletedEventArgs e)
    {
        System.Windows.Forms.WebBrowser ie = (System.Windows.Forms.WebBrowser)sender;
        ie.ShowPrintPreviewDialog();
                
    }
