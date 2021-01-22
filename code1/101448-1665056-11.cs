    public class WhateverController : Controller
    {
        [Authorize]
        public ActionResult WhateverAction()
        {
            ViewData["LoggedInAs"] = string.Format("You are logged in as {0}.", User.Identity.Name;
            Return View();
        }
    }
