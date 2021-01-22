    [HttpPost]
    [AllowAnonymous]
    public ActionResult ForgotPassword(ForgotPasswordModel model)
        {
          .
          .
          .  
          .
                    if (WebSecurity.UserExists(model.UserName))
                    {
                   var token = WebSecurity.GeneratePasswordResetToken(model.UserName, 60);
                      .
                      .
                      .
                      .                        
                        // send this token by email
                    }
                    else
                    {
                        ModelState.AddModelError("", "Could not find User");
                    }
                }
          return View(model);
        }
     [HttpPost]
         public ActionResult ResetPassword( ResetPasswordModel model)
        {
            string token = Request.Params["token"];
            if (!string.IsNullOrEmpty(token))
            {
                if (WebSecurity.ResetPassword(token, model.NewPassword))
                {
            // send email…….. or                                          
                    return View();
                }
            }
