     [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordVM changePasswordVM, string returnUrl = null)
        {
            LeaveUser _User = await _userManager.GetUserAsync(User);
            if (ModelState.IsValid)
            {
                if (changePasswordVM.NewPassword == changePasswordVM.ConfirmNewPassword)
                {
                    var result = await _userManager.ChangePasswordAsync(_User, changePasswordVM.CurrentPassword, changePasswordVM.NewPassword);
                    if (result.Succeeded)
                    {
                        if (returnUrl == null)
                            return RedirectToAction("Index", "Home");
                        else
                            return LocalRedirect(returnUrl);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Password Change Attempt. Password must be at least 8 characters.");
                }
            }
            return View();
