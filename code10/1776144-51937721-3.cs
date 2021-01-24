    public class HomeController : Controller
    {
        [ActionName("HelloWorld")]
        public string MyCoolAction(string arg1, string arg2, int arg4)
        {
            return ActionNameExtensions<HomeController>.FindActionName(
                controller => controller.MyCoolAction("a", "b", 3)
            );
        }
    }
