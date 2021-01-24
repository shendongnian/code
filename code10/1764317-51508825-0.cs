    services.AddIdentityServer()
    .AddConfigurationStore(options => {
                    // Loop through and rename each table to 'idn_{tablename}' - E.g. `idn_ApiResources`
                    foreach(var p in options.GetType().GetProperties()) {
                    if (p.PropertyType == typeof(IdentityServer4.EntityFramework.Options.TableConfiguration))
                    {
                        object o = p.GetGetMethod().Invoke(options, null);
                        PropertyInfo q = o.GetType().GetProperty("Name");
                        string tableName = q.GetMethod.Invoke(o, null) as string;
                        o.GetType().GetProperty("Name").SetMethod.Invoke(o, new object[] { $"idn_{tableName}" });
                        
                    }
                }
             // Configure DB Context connection string and migrations assembly where migrations are stored  
                options.ConfigureDbContext = builder => builder.UseNpgsql(_configuration.GetConnectionString("IDPDataDBConnectionString"),
                    sql => sql.MigrationsAssembly(typeof(IdentityServer.Data.DbContexts.MyTestDbContext).GetTypeInfo().Assembly.GetName().Name));
    }
    .AddOperationalStore(options => { 
     // Copy and paste from AddConfigurationStore logic above.
    }
