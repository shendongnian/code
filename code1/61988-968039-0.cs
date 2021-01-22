    interface IWebRequestable { 
         HttpWebRequest Request {get;}   // Right class? Not sure.
    }
    public class BaseUserControl : UserControl, IWebRequestable {}
    public class BaseController : Controller, IWebRequestable {}
    public class BasePage : Page, IWebRequestable {}
    public static class CurrentUserMixin {
        public static User GetCurrentUser(this IWebRequestable RequestObject) {
             // Put your User code here
        }
    }
