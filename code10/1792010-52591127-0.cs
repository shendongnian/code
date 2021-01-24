    if (result.Succeeded)
    {
        //var code = await _userManager.GenerateEmailConfirmationTokenAsync(user.Id);
        //var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code }, protocol: Request.Url.Scheme);
        //await _userManager.SendEmailAsync(user.Id, "Confirme sua Conta", "Por favor confirme sua conta clicando neste link: <a href='" + callbackUrl + "'></a>");
        //ViewBag.Link = callbackUrl;
        return RedirectToAction("ListUsers", "Account");
    }
