     public class MyTestBaseClass
     {
      protected ServiceCollection Services { get; set; } = new ServiceCollection();
      MyTestBaseClass
     {
       Services.AddDigiTebFrameworkServices();
            Services.AddDigiTebDBContextService<DigiTebDBContext> 
            (Consts.MainDBConnectionName);
            Services.AddDigiTebIdentityService<User, Role, DigiTebDBContext>();
            Services.AddDigiTebAuthServices();
            Services.AddDigiTebCoreServices();
            Services.AddSingleton<IHttpContextAccessor>(new HttpContextAccessor() { HttpContext = new DefaultHttpContext() { RequestServices = Services.BuildServiceProvider() } });
    }
    }
