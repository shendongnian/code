    public abstract class BaseController : Controller
    {
        public abstract string Localization { get; }
    }
    
    public class MyController1 : BaseController
    {
        public override string Localization => "en";
    }
