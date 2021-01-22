    public class WebsiteURLs
    {
       #region StoreURLs sub-class
       // One category of urls on the website is the store.
       public class StoreURLs
       {
         private WebsiteURLs _website;
         public class StoreURLs(WebsiteURLs website)
         {
           _website = website;
         }
         public string BestSellers
         { 
            get { return _website.ResolveURL("~/store/bestSellers.html"); }
         }
       }
       #endregion
    
       #region StoreURLs prop. accessor
       private StoreURLs _store;
       public StoreURLs Store // property for generating store urls
       {
         get
         {
            if (_store == null ) {
              _store = new StoreURLs(this);
            }
            return _store;
         }
       }
       #endregion
       
       #region Homepage
       public string Homepage
       {
           get { return ResolveURL("~/default.aspx"); }
       }
       #endregion
    
       #region Methods
       // .. Other Categories Here
       protected string ResolveURL(string url)
       {
         return HttpContext.Current.Response.ApplyAppPathModifier(url);
       }
       #endregion
    }
