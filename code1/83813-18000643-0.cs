    PagesSection pagesSection = ConfigurationManager.GetSection("system.web/pages") as PagesSection;
    if ((null != pagesSection) && (pagesSection.EnableSessionState == PagesEnableSessionState.True))
        // Session state is enabled
    else
        // Session state is disabled (or readonly)
