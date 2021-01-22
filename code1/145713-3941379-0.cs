                try
                {
                    
                    xdsRSS.DataFile = Configuration.BeaconConfigurationSection.Current.SyndicatedJobs.RssUrl;
                    xdsRSS.XPath = Configuration.BeaconConfigurationSection.Current.SyndicatedJobs.XPath;
                    xdsRSS.EnableCaching = true;
                    xdsRSS.CacheExpirationPolicy = DataSourceCacheExpiry.Absolute;
                    xdsRSS.CacheDuration = 6000;
                    dlRSS.DataSource = xdsRSS;
                    dlRSS.DataBind();
                }
                catch
                {
                    dlRSS.Visible = false;
                    pnlLinkToJobSite.Visible = true;
                }
