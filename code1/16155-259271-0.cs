    protected bool IsDebugMode
    {
        get
        {
            System.Web.Configuration.CompilationSection tSection;
            tSection = ConfigurationManager.GetSection("system.web/compilation") as System.Web.Configuration.CompilationSection;
            if (null != tSection)
            {
                return tSection.Debug;
            }
            /* Default to release behavior */
            return false;
        }
    }
