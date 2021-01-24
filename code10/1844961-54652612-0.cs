    public class BaseController : Controller {
        public virtual Tenant Tenant {
            get { return HttpContext.Items["Tenant"] as Tenant; }
        }
    }
