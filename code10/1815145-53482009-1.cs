        [AttributeUsage(AttributeTargets.Method,
            AllowMultiple = false, Inherited = false)]
    public class OutputCacheVary : OutputCacheAttribute
    {
        public OutputCacheVary()
        {
        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string paramText = filterContext.ActionParameters["sefLink"].ToString();
            if (paramText == "blablabla.html")
            {
                NoStore = true;
            }
            else
            {
                Duration = 3600;
                VaryByCustom = "none";
            }
        }
    }
