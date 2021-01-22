    public class SiteDisplayInfo
    {
        public int Id {get;set;}
        public string SiteName {get;set;}
        public string PrimaryAddress {get;set;}
    
        public static readonly Dictionary<string, Func<IQueryable<Site>, IOrderedQueryable<Site>>> OrderByFuncs = 
        new Dictionary<string, Func<IQueryable<Site>, IOrderedQueryable<Site>>>
        {
            {"Id", q => q.OrderBy(s => s.Id)},
            {"SiteName", q => q.OrderBy(s => s.SiteName)},
            {"PrimaryAddress", 
            q => q.OrderBy(s => s.PrimaryAddress.AddressLine1)
                                 .ThenBy(s => s.PrimaryAddress.City)}
        };
    }
    
    ...
    public IEnumerable<SiteDisplayInfo> GetSites(string orderByString)
    {
        IQueryable<Site> sites = DataBase.Sites;
        if (orderByString != null && SiteDisplayInfo.OrderByFuncs.ContainsKey(orderByString))
        {
            sites = SiteDisplayInfo.OrderByFuncs[orderByString](sites);
        }
        var query = from s in sites
                    select new SiteDisplayInfo
                    {
                        Id = s.Id,
                        SiteName = s.SiteName,
                        PrimaryAddress = s.PrimaryAddress.AddressLine1 + s.PrimaryAddress.City
                    };
        return query.ToList();
    }
