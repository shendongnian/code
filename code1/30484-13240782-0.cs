    public class HttpInternationalizationAttribute : ActionFilterAttribute
    {
        private static readonly HashSet<string> Langs = new HashSet<string>(CultureInfo.GetCultures(CultureTypes.NeutralCultures)
                                                                               .Select(x => x.TwoLetterISOLanguageName.ToUpper()));
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var language = (string)actionContext.ControllerContext.RouteData.Values["language"];
            if (!string.IsNullOrEmpty(language) && Langs.Contains(language.ToUpper()))
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(language);
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(language);
            }
        }
    }
