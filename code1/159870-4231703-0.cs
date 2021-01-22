        public ActionResult LogOn(string returnUrl)
        {
            if (!string.IsNullOrEmpty(returnUrl))
            {
                TempData["ReturnUrl"] = returnUrl;
            }
            return View();
        }
        [HttpPost]
        public ActionResult LogOn(LogOnModel model, FormCollection collecton)
        {
            if (ModelState.IsValid)
            {
                AuthenticationResult logonStatus = TransactionScriptFactory.GetTransactionScript<UserTransactionScripts>()
                                                                           .LogOn(model.Email, model.Password);
                if (logonStatus.AuthResult == AuthResultEnum.Success)
                {
                    FormsService.SignIn(logonStatus.User.UserId, logonStatus.User.NickName, false);
                    object returnUrl = string.Empty;
                    TempData.TryGetValue("ReturnUrl", out returnUrl);
                    string returnUrlStr = returnUrl as string;
                    if (!string.IsNullOrEmpty(returnUrlStr))
                    {
                        return Redirect(returnUrlStr);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
