    namespace Mvc.Controllers
    {
    
        using System;
        using System.Web.Mvc;
               
        public class HomeController : ClientController
        {
            public ActionResult Index()
            {
                string ip = Request.UserHostAddress;
    
                ...
            }
        }
    }
