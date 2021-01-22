    [Authorize, AcceptVerbs(HttpVerbs.Post)]
    public ActionResult ChangePassword(string oldPassword, string newPassword, string confirmPassword)
    {
        var oldPasswordValidationResults = _validatorProvider.Validate<IStringLengthValidator>(oldPassword);
        oldPasswordValidationResults.Where(r => !r.Passed).Each(r => ModelState.AddModelError("OldPassword", "Please enter your old password."));
        var newPasswordValidationResults = _validatorProvider.Validate<IStringLengthValidator>(newPassword);
        newPasswordValidationResults.Where(r => !r.Passed).Each(r => ModelState.AddModelError("NewPassword", "Please enter a new password."));
        if (newPassword != confirmPassword)
            ModelState.AddModelError("ConfirmPassword", "The passwords do not match.");
        if (!_userMembershipService.ChangePassword(oldPassword, newPassword))
            ModelState.AddModelError("_FORM", "Unable to change your password.");
        if (!ModelState.IsValid)
            return View();
        return View("ChangePasswordSuccessful");
    }
