    public IServiceProvider ConfigureServices(IServiceCollection services)
    {
        ... services registration part ommited
        var builder = new ContainerBuilder();
        builder.Populate(services);
        builder.Register(context=>
        {
            var identityUser = context.Resolve<IHttpContextAccessor>()?.HttpContext?.User;
            var userInfo = new UserInfo()
            {
                Name=//get it from identityUser.Claims 
                Id= //get it from identityUser.Claims
            }
            return userInfo;
        }).AsSelf()
          .InstancePerLifetimeScope();
    }
