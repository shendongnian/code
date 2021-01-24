    public static class Extensions
        {
            public static string ChangePasswordCallbackLink(this IUrlHelper urlHelper, string appUserId, string parameter)
            {
                return urlHelper.Action(
                    action: nameof(HomeController.ChangePassword),
                    controller: "Home",
                    values: new { appUserId, parameter }
                );
            }
        }
        public class HomeController : Controller
        {
            public IActionResult ChangePassword(string appUserId, string parameter)
            {
                return View();
            }
            public IActionResult Index()
            {
                var link = Url.ChangePasswordCallbackLink("123", "qwerty");
                return View(model: link);
            }
        }
  
