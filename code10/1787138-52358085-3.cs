    using System;
    using System.Web.Mvc;
    using Test.Models;
    namespace Test.Controllers
    {
        public class TestController : Controller
        {
            public ActionResult Hello(UserInfo userInfo)
            {
                if (!String.IsNullOrEmpty(userInfo.Name))
                    ViewBag.Message = "Success";
                return View(userInfo);
            }
        }
    }  
  
