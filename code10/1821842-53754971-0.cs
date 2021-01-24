    [Authorize(Roles = "Administrator, PowerUser")]
    public class ControlPanelController : Controller
    {
        public ActionResult SetTime()
        {
        }
        [Authorize(Roles = "Administrator")]
        public ActionResult ShutDown()
        {
        }
    }
