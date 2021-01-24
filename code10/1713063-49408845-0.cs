    public class HomeController : Controller
    {
        private readonly string _SessionGuid = 
            Trace.CorrelationManager.ActivityId.ToString();
    ....
    }
