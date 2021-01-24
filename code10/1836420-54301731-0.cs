        public class HomeController : Controller
        {
            public IActionResult Index()
            {
                List<SelectListItem> select = new List<SelectListItem>
                {
                    new SelectListItem("Tom","Tom"),
                    new SelectListItem("Jack","Jack"),
                    new SelectListItem("Vicky","Vicky")
                };
                ViewBag.Select = select;
                return View();
            }
            [HttpPost]
            public async Task<IActionResult> Login(string userName)
            {
                await HttpContext.SignOutAsync();
                var identity = new ClaimsIdentity();
                identity.AddClaim(new Claim(ClaimTypes.Name, userName));
                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index");
            }
        }
