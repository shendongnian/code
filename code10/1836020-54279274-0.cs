      //
      // GET: /Account/ResetPassword
      [AllowAnonymous]
      public ActionResult ResetPassword(string code)
      {
         return code == null ? View("Error") : View();
      }
      //
      // POST: /Account/ResetPassword
      [HttpPost]
      [AllowAnonymous]
      [ValidateAntiForgeryToken]
      public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
      {
         if (!ModelState.IsValid)
         {
            return View(model);
         }
         var user = await UserManager.FindByNameAsync(model.Email);
         if (user == null)
         {
            // Don't reveal that the user does not exist
            return RedirectToAction("ResetPasswordConfirmation", "Account");
         }
         var result = await UserManager.ResetPasswordAsync(user.Id, model.Code, model.Password);
         if (result.Succeeded)
         {
            return RedirectToAction("ResetPasswordConfirmation", "Account");
         }
         AddErrors(result);
         return View();
      }
