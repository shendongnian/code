    public class MessageController : Controller
    {
      public ActionResult Create()
      {
        return View();
      }
    
      [AcceptVerbs(HttpVerbs.Post)]
      public ActionResult Create( Message message )
      {
        try
        {
          // Exceptions for flow control are so .NET 1.0 =)
          // ... your save code here
        }
        catch
        {
          // Ugly catch all error handler - do you really know you can fix the problem?  What id the database server is dead!?!
          return View();
        }
      }
    }
