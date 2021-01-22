    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using System.Web.Mvc.Ajax;
    
    namespace testapp.Controllers
    {
        [ValidateInput(false)]
        public class MyTestController : Controller
        {
    
            public ActionResult Index()
            {
                return View();
            }
    
        }
    }
