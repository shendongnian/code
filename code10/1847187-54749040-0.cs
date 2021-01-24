    public void WebsiteList(string[] blocked_sites)
    {
        numofsites = blocked_sites.Length;
        string[] s = new string[numofsites];
        for (int i = 0; i < numofsites; ++i)
        {
            s[i] = string.Format("•   {0}{1}", blocked_sites[i].Replace("*://*.", "").Replace("*://*", "").Replace("*://", "").Replace("/*", ""),
                Environment.NewLine);
        }
        ic.ItemsSource = s;
    }
