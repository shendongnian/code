    public abstract class ApplicationController : Controller 
    {
        protected ApplicationController()
        {
            string myuser = this.User.Identity.Name;
        } 
    }
