    Public class BaseController : Controller
    {
       public BaseController()
       {
         if((bool.Parse(Session["isAuthenticated"]))
         {
           // write the user specific code here.
         }
      }
