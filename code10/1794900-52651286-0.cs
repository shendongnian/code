        public class ValidationPermission : ActionFilterAttribute
        {
         public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
             if(System.Web.HttpContext.Current.Session["UserName"] == null)
             System.Web.HttpContext.Current.Response.RedirectToRoute("Login");
             else{
             // code check CheckPermission
                 }
            }
        }
