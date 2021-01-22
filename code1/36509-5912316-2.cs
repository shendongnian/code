    public static class PageHelpers
    {
        public static void RequireOrPermanentRedirect<T>(this System.Web.UI.Page page, string QueryStringKey, string RedirectUrl)
        {
            string QueryStringValue = page.Request.QueryString[QueryStringKey];
    
            if(String.IsNullOrEmpty(QueryStringValue))
            {
                page.Response.RedirectPermanent(RedirectUrl);
            }
    
            try
            {
                T value = (T)Convert.ChangeType(QueryStringValue, typeof(T));
            }
            catch
            {
                page.Response.RedirectPermanent(RedirectUrl);
            }
        }
    }
