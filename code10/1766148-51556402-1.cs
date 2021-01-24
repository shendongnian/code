    public abstract class BaseController : Controller {
        protected virtual new CustomPrincipal User {
            get { return base.User as CustomPrincipal; }
        }
    }
