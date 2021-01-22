    public void myButton_OnClick(EventArgs e, object sender)
    {
        VisitWebSites();
    }
    private void VisitWebSites()
    {
        var webSiteList = GetWebSitesFromFile();
        StartVisitingWebSites(webSiteList);
    }
