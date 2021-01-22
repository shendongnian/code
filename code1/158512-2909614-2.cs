    public class ControllerA:Controller
    {
        public ActionResult Index()
        {
            return List();
        }
    
        public ActionResult List()
        {
        //List function
        }
    }
    
    
    public class ControllerB:Controller
    {
        public ActionResult Index()
        {
            return Draw();
        }
    
        public ActionResult Draw()
        {
        //Draw function
        }
    }
