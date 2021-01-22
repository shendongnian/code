      public ActionResult Index()
        {                        
            string cacheKey = string.Format("FeaturedProducts-{0}",WebsiteId);
            IList<Product> productList = this.HttpContext.Cache[cacheKey] as IList<Product>;
            
            //My app keeps a list of website contexts in the Application. This test returns 1 based on the unit / int tests or a real world db value when hosted on IIS etc..
            int websiteId = (int)HttpContext.Application[this.Request.Url.Host];
