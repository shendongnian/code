    private Task<List<Site>> UpdateSites(List<Site> sites)
    {
        return sites.Select(x => FetchSite(site.SiteId))
    }
    
    
    public Task<SiteSimple> FetchSite(int siteId)
    {
        var url = $"/site/{siteId}/simple";
        return ExecuteRestRequest<SiteSimple>(url, Method.GET);
    }
