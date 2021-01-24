                using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var IdentityContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                IdentityContext.Database.EnsureCreated();
            }
