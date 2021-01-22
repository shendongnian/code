    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    namespace MvcApplication2.Controllers
    {
    [HandleError]
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Title"] = "Home Page";
            ViewData["Message"] = "Welcome to ASP.NET MVC!";
            return View();
        }
       
        public ActionResult About()
        {
            ViewData["Title"] = "About Page";
            return View();
        }
        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            if ((string)(filterContext.RouteData.Values["action"]) == "Index")
            {
                filterContext.Cancel = true;
                filterContext.Result = Index();
            }
        }
    }
    }
