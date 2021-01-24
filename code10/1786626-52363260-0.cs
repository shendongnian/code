                services.AddTransient((serviceProvider)=> new Claim { Type = "T1", Value = "V1" });
            services.AddMvc(c =>
                            {
                                c.Filters.Add(typeof(RequestLoggerActionFilter));
                                c.Filters.Add(typeof(ClaimRequirementFilter));
                                //c.Filters.Add(new ClaimRequirementFilter(new Claim { Type = "T1", Value = "V1" }));
                            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
