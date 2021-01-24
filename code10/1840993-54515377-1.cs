    [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Invited([FromForm] InvitedViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Error = "invalid model";
                return View(model);
            }
            if (!model.Password.Equals(model.ConfirmPassword))
            {
             
                model.Error = "Passwords must match";
                return View(model);
            }
            if (model.Terms != null && !model.Terms.All(t => t.Accept))
            {
                return View(model);
            }
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {             
                // Don't reveal that the user does not exist
                return RedirectToAction(nameof(Login), new { message = ManageMessageId.InvitedFailedError, messageAttachment = "User Not invited please invite user again." });
            }
            
            var result = await _userManager.ResetPasswordAsync(user, Uri.UnescapeDataString(model.Code), model.Password);
            if (result.Succeeded)
            {            
                return Redirect(_settings.Settings.XenaPath);
            }
            var errors = AddErrors(result);
                        return RedirectToAction(nameof(Login), new { message = ManageMessageId.InvitedFailedError, messageAttachment = errors });
        }
