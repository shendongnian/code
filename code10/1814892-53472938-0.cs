    var host = CreateWebHostBuilder(args).Build();
    
    try
    {
        var scope = host.Services.CreateScope(); <-- Need this
    
        var roleMgr = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
    
    host.Run();
