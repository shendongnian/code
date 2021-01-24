    [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Invited([FromQuery] InviteUserRequest request)
        {
            if (request.Code == null)
            {
                RedirectToAction(nameof(Login));
            }
            var user = await _userManager.FindByIdAsync(request.UserId.ToString());
            if (user == null)
             {
              return View("Error");
            }
            var validateCode = await _userManager.VerifyUserTokenAsync(user, _userManager.Options.Tokens.PasswordResetTokenProvider, "ResetPassword", Uri.UnescapeDataString(request.Code));
            if (!validateCode)
            {
             return RedirectToAction(nameof(Login), new { message = ManageMessageId.PasswordResetFailedError, messageAttachment = "Invalid code." });
            }
            await _userManager.EnsureEmailConfirmedAsync(user);
            await _userManager.EnsureLegacyNotSetAsync(user);
            return View(new InvitedViewModel { Error = string.Empty, Email = user.Email, Code = request.Code, UserId = user.Id });
        }
