      protected void btnscreenshot_click(object sender, EventArgs e)
      {
        //  btnscreenshot.Visible = false;
        allpanels.Visible = true;
        Thread thread = new Thread(GenerateThumbnail);
        thread.SetApartmentState(ApartmentState.STA);
        thread.Start();
        thread.Join();
    }
    private void GenerateThumbnail()
    {
        //  btnscreenshot.Visible = false;
        WebBrowser webrowse = new WebBrowser();
        webrowse.ScrollBarsEnabled = false;
        webrowse.AllowNavigation = true;
        string url = txtweburl.Text.Trim();
        webrowse.Navigate(url);
        webrowse.Width = 1400;
        webrowse.Height = 50000;
        webrowse.DocumentCompleted += webbrowse_DocumentCompleted;
        while (webrowse.ReadyState != WebBrowserReadyState.Complete)
        {
            System.Windows.Forms.Application.DoEvents();
        }
    }
