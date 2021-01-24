    services.AddMvcCore().AddVersionedApiExplorer(
                    opt =>
                    {
                        // Capital V is verbose of version #.
                        opt.GroupNameFormat = "'v'VVV";
                        // This line converts the placeholder to actual version
                        opt.SubstituteApiVersionInUrl = true;
                    });
