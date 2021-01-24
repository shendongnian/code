    services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new Info { Title = "Some API", Version = "v1" });
                    c.AddSecurityDefinition("Bearer", new ApiKeyScheme()
                    {
                        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                        Name = "Authorization",
                        In = "header",
                        Type = "apiKey"
                    });
                    c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>>
                    {
                        { "Bearer", new string[] { } }
                    });
                });
