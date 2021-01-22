    public void myButton_OnClick(EventArgs e, object sender)
    {
        VisitWebSites();
    }
    private void VisitWebSites()
    {
        var webSiteList = GetWebSitesFromFile();
        foreach (var w in webSiteList) {
            StartVisitingWebSite(w);
        }
    }
    private IEnumerable<string> GetWebSitesFromFile()
    {
        // whatever
    }
    private void StartVisitingWebSite(string url)
    {
        // whatever
    }
