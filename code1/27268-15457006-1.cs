    public class CreateRepositoryByUser : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            CreateRepository(filterContext);
        }
        public static void CreateRepository(ActionExecutingContext filterContext)
        {
            if (filterContext.Controller.ViewData["repository"] == null)
            {
                filterContext.Controller.ViewData["repository"] =
                    MFCRepository.CreateMFCRepository(filterContext.Controller.ControllerContext.HttpContext.User);
            }
        }
    }
