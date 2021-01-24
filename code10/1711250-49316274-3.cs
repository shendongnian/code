    ServiceProvider provider = new ServiceCollection()
                                   .AddScoped<IDBAction<DBRepo>, dbCRUD<DBRepo>>()
    .AddScoped<CoreContext>()
                                       .BuildServiceProvider();
     provider.GetService<IDBAction<DBRepo>>().InsertData(_ua);
