    [Authorize]
    public class DefaultController : Controller
    {
        public DefaultController(IHttpContextAccessor contextAccessor)
        {
            // Here HttpContext is not Null :)
            var authenticatedUser = contextAccessor.HttpContext.User.Identity.Name;
        }
    }
