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
        backgroundWorker1.RunWorkerAsync(url);
    }
    private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
    {
        string url = (string)e.Argument;
        e.Result = VisitWebSite(url);
    }
    private string VisitWebSite(string url)
    {
        // This is called in background thread.  Do whatever you do to return data.
    }
    private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        if (e.Error || e.Cancelled)
            return;
        string result = e.Result.ToString();
        // Do whatever you do with the result
    }
