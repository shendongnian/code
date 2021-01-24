    public class BaseApiController : ApiController {
        private ModelFactory _modelFactory;
        private ApplicationUserManager _AppUserManager = null;
        private ApplicationRoleManager _AppRoleManager = null;
    
        protected string GetRole() {
            return Request.GetOwinContext()
                .GetUserManager<ApplicationRoleManager>()
                .FindById(User.Identity.GetUserId()).Name;     
        }
