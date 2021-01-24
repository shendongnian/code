    private void addTab()
    {
          TabPage tabPage = new TabPage();
          tabPage.Text = "New Tab";
          WebControl wc = new WebControl();
          wc.Dock = DockStyle.Fill;
          wc.webBrowser1.Navigate("www.google.com");
          tabPage.Controls.Add(wc);
          tabControl1.Controls.Add(tabPage);
    }
