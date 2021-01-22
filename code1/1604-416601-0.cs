      public class Page : System.Web.UI.Page
      {
        protected override void OnLoad(EventArgs e)
        {
            try
            {
                string cacheKey = "cacheKey";
                object cache = HttpContext.Current.Cache[cacheKey];
                if (cache == null)
                {
                  HttpContext.Current.Cache[cacheKey] = DateTime.UtcNow.ToString();
                }
               
                Response.AddCacheItemDependency(cacheKey);
            }
            catch (Exception ex)
            {
                throw new SystemException(ex.Message);
            }
            base.OnLoad(e);
        }     
     }
      // Clear All OutPutCache Method    
       
        public void ClearAllOutPutCache()
        {
            string cacheKey = "cacheKey";
            HttpContext.Cache.Remove(cacheKey);
        }
    
