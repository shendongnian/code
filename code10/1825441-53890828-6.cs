    public class AddUserToViewDataFilterAttribute : ActionFilterAttribute
    {
        private DBContext db = new DBContext();
        public void OnActionExecuting(ActionExecutingContext context)
        {
          var user = context.Controller.User;
          var userInfo = new UserInfo
          {
            HasUser = !string.IsNullOrEmpty(User.Identity?.Name),
            User = !string.IsNullOrEmpty(User.Identity?.Name)
              ? db.Users
            .Where(m => m.username.Equals(User.Identity.Name)).FirstOrDefault()
              : null;
          };
          context.ControllerContext.ViewData.SetUserInfo(userInfo);
        }
    }
