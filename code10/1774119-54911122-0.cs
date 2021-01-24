    public void ConfigureContainer(ContainerBuilder builder)
    {
        builder.RegisterType<UserService>().As<IUserService>();
    }
You must use ConfigureTestContainer rather than ConfigureTestServices as follows:
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureTestContainer<ContainerBuilder>(containerBuilder =>
            {
                containerBuilder.RegisterType<TestUsersService>().As<IUserService>();
            });
    }
