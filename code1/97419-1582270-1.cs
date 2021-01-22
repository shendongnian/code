    public class WebHelper
        {
            #region Helper functions
            public static SPWeb GetWeb(SPFeatureReceiverProperties prop)
            {
                using (SPSite site = prop.Feature.Parent as SPSite)
                {
                    return site != null ? site.RootWeb : prop.Feature.Parent as SPWeb;
                }
            }
            #endregion  
        }
