    public static void Config(AuthorizationOptions configure, IConfiguration configuration)
    {
        configure.DefaultPolicy = null;
        //Configuration.Bind("AuthMiddlewareOptions", myoptions);
    }
