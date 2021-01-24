    services.AddDataProtection()
        .PersistKeysToFileSystem(GetKeyRingDirInfo())
        .SetApplicationName("SharedCookieApp");
    
    services.ConfigureApplicationCookie(options => {
        options.Cookie.Name = ".AspNet.SharedCookie";
    });`
