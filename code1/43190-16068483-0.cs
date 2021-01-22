    using Microsoft.Web.Administration;
     public class IisSiteApplicationList : List<IisSiteApplication>
        {
            public IisSiteApplicationList()
            {
                ServerManager iisManager = new ServerManager();
                SiteCollection sites = iisManager.Sites;
                foreach (Site iisSite in sites)
                {
                    foreach (Application iisApp in iisSite.Applications)
                    {
                        IisSiteApplication app = new IisSiteApplication
                            {
                                SiteId = iisSite.Id,
                                SiteName = iisSite.Name,
                                 AppName = iisApp.ToString(),
                                ApplicationPoolName = iisApp.ApplicationPoolName,
                                Directories =
                                    String.Join(";", iisApp.VirtualDirectories.Select(a =>   a.PhysicalPath).ToArray())
                            };
                        Add(app);
                    }
                }
            }
        }
