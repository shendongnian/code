    public static class DbInitializer
        {
            public static void Migrate<T>(IApplicationBuilder app) where T : DbContext
            {
                using (var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    scope.ServiceProvider.GetRequiredService<T>().Database.Migrate();
                }
            }
        }
