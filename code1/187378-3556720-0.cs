    namespace MyApp.Controllers 
    { 
        public class DevicesController : Controller 
        { 
     
            [AcceptVerbs(HttpVerbs.Post)] 
            public ActionResult SetValue(int temp){ 
               HttpContext.Current.Session["some_var"] = temp; 
               return RedirectToAction("DisplayValue"); 
            } 
     
            [Authorize] 
            public ActionResult DisplayValue(){ 
     
              ....  
              return View((int)HttpContext.Current.Session["some_var"]); 
            } 
         } 
    } 
