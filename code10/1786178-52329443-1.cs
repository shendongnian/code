    services.AddTransient<Claim>();
            services.AddMvc(c =>
                            {
                                c.Filters.Add(typeof(RequestLoggerActionFilter));
                                c.Filters.Add(typeof(ClaimRequirementFilter));
                            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
