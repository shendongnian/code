    public class MenuPartsViewComponent : ViewComponent {
        public IViewComponentResult Invoke() {
            if (HttpContext.User.Identity.Name == null) {
                var login = Url.Action("Login", "Account");
                var html = @"<li><a href=""{0}"" class=""navbar-brand"">Login</a></li>";
                return new HtmlContentViewComponentResult(
                    new HtmlString(string.Format(html, login))
                );
            } else {
                var logout = Url.Action("Logout", "Account");
                var html = @"<li><a href=""{0}"" class=""navbar-brand"">Logout</a></li>";
                return new HtmlContentViewComponentResult(
                    new HtmlString(string.Format(html, logout))
                );
            }
        }
    }
