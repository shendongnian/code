     private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (current_tab_count == 10) return;
            TabPage tabPage = new TabPage("Loading...");
            tabpages.Add(tabPage);
            tabControl1.TabPages.Add(tabPage);
            current_tab_count++;
            ExtendedWebBrowser browser = new ExtendedWebBrowser();
            InitializeBrowserEvents(browser);
            webpages.Add(browser);
            browser.Parent = tabPage;
            browser.Dock = DockStyle.Fill;
            browser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(browser_DocumentCompleted);
            browser.DocumentTitleChanged += new EventHandler(Browser_DocumentTitleChanged);
            browser.Navigated += Browser_Navigated;
            browser.IsWebBrowserContextMenuEnabled = true;
    public void InitializeBrowserEvents(ExtendedWebBrowser browser)
        {
            browser.NewWindow2 += new EventHandler<ExtendedWebBrowser.NewWindow2EventArgs>(Browser_NewWindow2);
        }
        void Browser_NewWindow2(object sender, ExtendedWebBrowser.NewWindow2EventArgs e)
        {
            if (current_tab_count == 10) return;
            TabPage tabPage = new TabPage("Loading...");
            tabpages.Add(tabPage);
            tabControl1.TabPages.Add(tabPage);
            current_tab_count++;
            ExtendedWebBrowser browser = new ExtendedWebBrowser();
            webpages.Add(browser);
            browser.Parent = tabPage;
            browser.Dock = DockStyle.Fill;
            browser.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(browser_DocumentCompleted);
            browser.DocumentTitleChanged += new EventHandler(Browser_DocumentTitleChanged);
            browser.Navigated += Browser_Navigated;
            tabControl1.SelectedTab = tabPage;
            browser.Navigate(textBox.Text);
            
            {
                e.PPDisp = browser.Application;
                InitializeBrowserEvents(browser); 
            }
