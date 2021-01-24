    private void MyCookiePolicyOptionsConfigurationMethod(CookiePolicyOptions options)
    {
        Func<HttpContext, bool> myCheckConsentNeeded = MyCheckConsentNeededMethod;
        options.CheckConsentNeeded = myCheckConsentNeeded;
        options.MinimumSameSitePolicy = SameSiteMode.None;
    }
    private bool MyCheckConsentNeededMethod(HttpContext context)
    {
        return true;
    }
