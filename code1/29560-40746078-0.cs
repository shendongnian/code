        public class CultureAttribute : ActionFilterAttribute
        {
            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                // Retreive culture from GET
                string currentCulture = filterContext.HttpContext.Request.QueryString["culture"];
                // Also, you can retreive culture from Cookie like this :
                //string currentCulture = filterContext.HttpContext.Request.Cookies["cookie"].Value;
                // Set culture
                Thread.CurrentThread.CurrentCulture = new CultureInfo(currentCulture);
                Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture(currentCulture);
            }
        }
