    System.Windows.Forms.WebBrowser browser = new System.Windows.Forms.WebBrowser();
    browser.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(browser_Navigating);
    
    
    void browser_Navigating(object sender, System.Windows.Forms.WebBrowserNavigatingEventArgs e)
    {
        _MyUrl = e.Url;
        e.Cancel;
    }
