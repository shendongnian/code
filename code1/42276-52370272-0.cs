    [Route("RequestResetPasswordToken/{email}/")]
    [HttpGet]
    [AllowAnonymous]
    public async Task<IHttpActionResult> GetResetPasswordToken([FromUri]string email)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var user = await UserManager.FindByEmailAsync(email);
        if (user == null)
        {
            Logger.Warn("Password reset token requested for non existing email");
			// Don't reveal that the user does not exist
            return NoContent();
        }
        //Prevent Host Header Attack -> Password Reset Poisoning. 
        //If the IIS has a binding to accept connections on 80/443 the host parameter can be changed.
        //See https://security.stackexchange.com/a/170759/67046
        if (!ConfigurationManager.AppSettings["AllowedHosts"].Split(',').Contains(Request.RequestUri.Host)) {
                Logger.Warn($"Non allowed host detected for password reset {Request.RequestUri.Scheme}://{Request.Headers.Host}");
                return BadRequest();
        }
        Logger.Info("Creating password reset token for user id {0}", user.Id);
        var host = $"{Request.RequestUri.Scheme}://{Request.Headers.Host}";
        var token = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
        var callbackUrl = $"{host}/resetPassword/{HttpContext.Current.Server.UrlEncode(user.Email)}/{HttpContext.Current.Server.UrlEncode(token)}";
        
        var subject = "Client - Password reset.";
        var body = "<html><body>" +
                   "<h2>Password reset</h2>" +
                   $"<p>Hi {user.FullName}, <a href=\"{callbackUrl}\"> please click this link to reset your password </a></p>" +
                   "</body></html>";
        var message = new IdentityMessage
        {
            Body = body,
            Destination = user.Email,
            Subject = subject
        };
        await UserManager.EmailService.SendAsync(message);
        return NoContent();
    }
	
	[HttpPost]
    [Route("ResetPassword/")]
    [AllowAnonymous]
    public async Task<IHttpActionResult> ResetPasswordAsync(ResetPasswordRequestModel model)
    {
        if (!ModelState.IsValid)
            return NoContent();
        var user = await UserManager.FindByEmailAsync(model.Email);
        if (user == null)
        {
            Logger.Warn("Reset password request for non existing email");
            return NoContent();
        }            
        if (!await UserManager.UserTokenProvider.ValidateAsync("ResetPassword", model.Token, UserManager, user))
        {
            Logger.Warn("Reset password requested with wrong token");
            return NoContent();
        }
        var result = await UserManager.ResetPasswordAsync(user.Id, model.Token, model.NewPassword);
        if (result.Succeeded)
        {
            Logger.Info("Creating password reset token for user id {0}", user.Id);
            const string subject = "Client - Password reset success.";
            var body = "<html><body>" +
                       "<h1>Your password for Client was reset</h1>" +
                       $"<p>Hi {user.FullName}!</p>" +
                       "<p>Your password for Client was reset. Please inform us if you did not request this change.</p>" +
                       "</body></html>";
            var message = new IdentityMessage
            {
                Body = body,
                Destination = user.Email,
                Subject = subject
            };
            await UserManager.EmailService.SendAsync(message);
        }
        return NoContent();
    }
	
	public class ResetPasswordRequestModel
    {
        [Required]
        [Display(Name = "Token")]
        public string Token { get; set; }
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 10)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
