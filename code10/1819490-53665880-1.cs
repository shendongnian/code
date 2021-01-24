    public class SomeController
    {
      public ActionResult UserView()
      {
        if (ViewBag.UserType == 1)
        {
          return Partial("PartialView/_StandardUser");
        }
        else if (ViewBag.UserType == 2)
        {
          return Partial("PartialView/_AdminUser");
        }
        return new EmptyResult();
      }
    }
