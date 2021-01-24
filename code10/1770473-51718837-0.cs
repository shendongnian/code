            app.Use(async (context,next) => {
                using (var serviceScope = app.ApplicationServices.CreateScope())
                {
                    if (true) //add your own logic to decide whether to run these code
                    {
                        var db = serviceScope.ServiceProvider.GetService<ApplicationDbContext>();
                        SeederModuleComponent seeder = new SeederModuleComponent(db);
                        seeder.Seeding();
                        // Seed the database.
                    }
                }
                await next();
            });
