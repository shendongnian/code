    public void WebBrowser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
    {
        //For the case when the control's Dock property is DockStyle.Fill
        this.Width = WebBrowser.Document.Body.ScrollRectangle.Width + 40; //40 is for border
        this.Height = WebBrowser.Document.Body.ScrollRectangle.Height + 40; //40 is for border
        //For the case when the control is not docked
        WebBrowser.Size = WebBrowser.Document.Body.ScrollRectangle.Size;
    }
