    [HttpGet]
    public IActionResult CorpLogin()
        {
            var authProperties = _signInManager
                .ConfigureExternalAuthenticationProperties("AzureAD",
                Url.Action("LoggingIn", "Account", null, Request.Scheme));
    
            return Challenge(authProperties, "AzureAD");
        }
