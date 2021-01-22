    public class BreadcrumbAttribute : ActionFilterAttribute
    {
        public string Page { get; set; }
        public BreadcrumbAttribute(string page)
        {
            Page = page;
        }
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var model = (IBreadcrumbs)filterContext.Controller.ViewData.Model;
            model.Breadcrumbs = BreadcrumbHelper.GetBreadCrumbs(string.Format("{0}", filterContext.RouteData.DataTokens["area"]), Page);
        }
    }
