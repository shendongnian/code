    [Authorize, AcceptVerbs(HttpVerbs.Post)]
    public ActionResult ChangePassword(string oldPassword, string newPassword, string confirmPassword)
    {
        var oldPasswordValidationResults = _validatorProvider.Validate<IStringLengthValidator>(oldPassword);
        oldPasswordValidationResults.Where(r => !r.Passed)
                                    .Each(r => ModelState.AddModelError("OldPassword", "Please enter your old password."));
        var newPasswordValidationResults = _validatorProvider.Validate<IStringLengthValidator>(newPassword);
        newPasswordValidationResults.Where(r => !r.Passed)
                                    .Each(r => ModelState.AddModelError("NewPassword", "Please enter a new password."));
        if (ModelState.IsValid) {
            if (newPassword == confirmPassword) {
                if (_userMembershipService.ChangePassword(oldPassword, newPassword)) {
                    return View("ChangePasswordSuccessful");
                }
                else {
                    ModelState.AddModelError("_FORM", "Unable to change your password.");
                }
            }
            else {
                ModelState.AddModelError("ConfirmPassword", "The passwords do not match.");
            }
        }
        return View();
    }
