    public class LocalizationAttribute : ActionFilterAttribute
    {
        private string _DefaultLanguage = "nl-NL";
        private string[] allowedLanguages = { "nl", "en" };
        public LocalizationAttribute(string defaultLanguage)
        {
            _DefaultLanguage = defaultLanguage;
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string lang = (string) filterContext.RouteData.Values["lang"] ?? _DefaultLanguage;
            LanguageHelper.SetLanguage(lang);
        }
    }
