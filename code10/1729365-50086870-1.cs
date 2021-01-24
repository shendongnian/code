    public class AccountController : Controller
    {
        private readonly IUserReadRepository userReadRepository;
        public AccountController()
        {
            this.userReadRepository = new UserReadRepository();
        }
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            bool found = this.userReadRepository.Get(model.Email, model.Password) != null;
            if (found)
            {
                FormsAuthentication.SetAuthCookie(model.Email, false);
                return RedirectToLocal(returnUrl);
            }
            ModelState.AddModelError("", "Invalid login attempt.");
            return View(model);
        }
        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (this.userReadRepository != null)
                {
                    this.userReadRepository.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        private ActionResult RedirectToLocal(string returnUrl)
        {
            // Just some safety work
            // If the returnUrl is somewhere on our site, go there
            // Otherwise, go to the home page
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }
    }
