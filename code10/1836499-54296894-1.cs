            #if DEBUG
            services.AddMvc(options =>
            {
                options.Filters.Add(new DebugFilter());
            })
            #else
            services.AddMvc()
            #endif
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
