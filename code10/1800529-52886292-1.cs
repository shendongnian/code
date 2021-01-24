    public class HomeController : Controller
    {
       TelemetryClient client = new TelemetryClient();
       public ActionResult Index()
       {
          RequestTelemetry r1 = new RequestTelemetry();
          r1.Name = "request message for testing";
          client.TrackRequest(r1);
          client.TrackTrace("trace message for testing wwwww.");
          client.TrackException(new Exception("exception message for testing wwwww."));
          ViewBag.Title = "Home Page";
    
          return View();
       }
    }
