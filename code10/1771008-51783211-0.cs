    public EntitlementsMaintenance AddCookie()
    {
        DriverProvider.GetDriver().Manage().Cookies.AddCookie(cookies);
        return this;
    }
