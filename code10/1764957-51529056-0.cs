    var properties = new AuthenticationProperties() { RedirectUri = RedirectUri };
    if (Code != null)
    {
        properties.Dictionary["AccessCode"] = Code;
    }
    context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
