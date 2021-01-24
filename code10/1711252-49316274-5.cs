    ServiceProvider provider = new ServiceCollection()
                                   .AddScoped(typeof(IDbAction<>), typeof(DbAction<>))
    .AddScoped<CoreContext>()
                                       .BuildServiceProvider();
    
     provider.GetService<IDBAction<DBRepo>>().InsertData(_ua);
