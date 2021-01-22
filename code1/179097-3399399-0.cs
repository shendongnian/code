        public override void Execute(Guid targetInstanceId)
        {
            foreach (SPSite site in this.WebApplication.Sites)
            {
                try
                {
                    if (SPSite.Exists(new Uri(site.Url)) && null != site.Features[FeatureId.AlertMeJob])
                    {
                        try
                        {
                            ExecuteJob(site);
                        }
                        catch (Exception ex)
                        {
                            // handle exception
                        }
                    }
                }
                finally
                {
                    site.Dispose();
                }
            }
        }
