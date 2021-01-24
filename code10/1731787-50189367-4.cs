      using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Web;
        using System.Web.Mvc;
        
        namespace stackoverflow.Controllers
        {
            public class TestController : Controller
            {
                // GET: Test
                public ActionResult Index()
                {
                    return View();
                }
        
        
                [HttpGet]
                public JsonResult GetJson()
                {
                    var list = new List<SelectOption>
                           {
                               new SelectOption { Value = "1", Text = "Aron" },
                               new SelectOption { Value = "2", Text = "Bob" },
                               new SelectOption { Value = "3", Text = "Charlie" },
                               new SelectOption { Value = "4", Text = "David" }
                           };
        
                    return Json(list, JsonRequestBehavior.AllowGet);
        
                }
            }
        }
