    [Route("[controller]/[action]")]
        public class BaseController : Controller
        {
            [HttpGet]
            public IActionResult GetCartViewComponent()
            {
                return ViewComponent("Cart");
            }
    
            [HttpPost]
            public IActionResult SetLanguage(string culture, string returnUrl)
            {
                Response.Cookies.Append(
                    CookieRequestCultureProvider.DefaultCookieName,
                    CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                    new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1)}
                );
    
                return LocalRedirect(returnUrl);
            }
        }
