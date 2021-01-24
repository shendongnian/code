    public class HomeController : Controller
    { 
       public ActionResult Putabc() 
      { 
         string RegNo = "abc"; 
         string tempUrl = Url.Action("Index", "User");
          return RedirectToAction(new { url = tempUrl + "?{RegNo}" }, 
         JsonRequestBehavior.AllowGet);
      }  
    }
