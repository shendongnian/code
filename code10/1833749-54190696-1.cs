    private async Task<List<Site>> UpdateSites(List<Site> sites)
    {
        var newSites = (await Task.WhenAll(sites.Select(site => FetchSite(site.SiteId))
                       .ToList();
        for(int i = 0; i < sites.Count; ++i)
        {
            sites[i].address = newSites[i].address;
            sites[i].phone= newSites[i].phone;
        }
        return sites;
    }
