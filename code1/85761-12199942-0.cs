    public static CustomErrorsMode GetRedirectMode()
    {
        Configuration config = WebConfigurationManager.OpenWebConfiguration("/");
        return ((CustomErrorsSection)config.GetSection("system.web/customErrors")).Mode;
    }
