    // Based on: http://geekswithblogs.net/shaunxu/archive/2010/05/06/localization-in-asp.net-mvc-ndash-3-days-investigation-1-day.aspx
    public class LocalisationAttribute : ActionFilterAttribute
    {
        public const string LangParam = "lang";
        public const string CookieName = "mydomain.CurrentUICulture";
        // List of allowed languages in this app (to speed up check)
        private const string Cultures = "en-GB en-US de-DE fr-FR es-ES ro-RO ";
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            // Try getting culture from URL first
            var culture = (string)filterContext.RouteData.Values[LangParam];
            
            // If not provided, or the culture does not match the list of known cultures, try cookie or browser setting
            if (string.IsNullOrEmpty(culture) || !Cultures.Contains(culture))
            {
                // load the culture info from the cookie
                var cookie = filterContext.HttpContext.Request.Cookies[CookieName];
                var langHeader = string.Empty;
                if (cookie != null)
                {
                    // set the culture by the cookie content
                    culture = cookie.Value;
                }
                else
                {
                    // set the culture by the location if not specified - default to English for bots
                    culture = filterContext.HttpContext.Request.UserLanguages == null ? "en-EN" : filterContext.HttpContext.Request.UserLanguages[0];
                }
                // set the lang value into route data
                filterContext.RouteData.Values[LangParam] = langHeader;
            }
            // Keep the part up to the "-" as the primary language
            var language = culture.Split(new char[] { '-' }, StringSplitOptions.RemoveEmptyEntries)[0];
            filterContext.RouteData.Values[LangParam] = language;
            // Set the language - ignore specific culture for now
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(language);
            // save the locale into cookie (full locale)
            HttpCookie _cookie = new HttpCookie(CookieName, culture);
            _cookie.Expires = DateTime.Now.AddYears(1);
            filterContext.HttpContext.Response.SetCookie(_cookie);
            // Pass on to normal controller processing
            base.OnActionExecuting(filterContext);
        }
    }
