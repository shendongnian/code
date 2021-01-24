        services.AddSession(opts => 
        {
            opts.Cookie.IsEssential = true; // make the session cookie Essential
        });
        services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
