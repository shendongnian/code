    public static partial class CMSiteServerExtensions
    {
        public static IQueryable<CMSiteServerAPIVM> ConvertToAPIVM(this IQueryable<CMSiteServer> Servers)
        {
            return Servers.Select(ss => new CMSiteServerAPIVM()
            {
                SiteServerID = ss.ID,
                Name = ss.Name,
                Description = ss.Description,
                ...
            }
        }
     }
