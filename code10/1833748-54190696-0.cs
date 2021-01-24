    private async Task<List<Site>> UpdateSites(List<Site> sites)
    {
        var fetchTasks = new List<Task>(sites.Count);
                         
        foreach (var site in sites)
        {
            fetchTasks.Add(Task.Run(async () => 
            {
                var newSite = await FetchSite(site.SiteId);
                site.address = newSite.address;
                site.phone = newSite.phone;
            }));
        }
        await Task.WhenAll(fetchTasks);
        return sites;
    }
