        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login(string returnUrl = null)
        {
            // Clear the existing external cookie to ensure a clean login process
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);
            ViewData["ReturnUrl"] = returnUrl;
            //HERE IS THE TRICK
            if (!string.IsNullOrEmpty(Request.QueryString.Value))
                return RedirectToAction("Login");
            return View();
        }
