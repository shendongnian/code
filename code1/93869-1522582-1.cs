    public class SuperUserFilterAttribute : LoggedUserFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            if (Logged)
            {
                MyBaseController controller = filterContext.Controller as MyBaseController;
                if (controller == null)
                    throw new Exception("Please use MyBaseController instead of built in Controller");
                
                User loggedUser = controller.Model.UserBO.GetUserByID(SessionManager.LoggedUser.UserID);
               
                if(!loggedUser.IsSuperUser)
                {
                    filterContext.Result = new RedirectToRouteResult(GetRedirectToNotAuthorizedRouteValues());
                }
            }
        }
    }
