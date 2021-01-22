    public class ContactController : Controller 
    {
      public ActionResult GetContact (int id) 
      {
        return Json(Contact.GetById(id), JsonRequestBehavior.AllowGet);
      }
    }
