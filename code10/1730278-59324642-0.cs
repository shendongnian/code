public void RegisterContext<TContext>(ContainerBuilder builder)
    where TContext : DbContext
{
    builder.Register(componentContext =>
        {
            var serviceProvider = componentContext.Resolve<IServiceProvider>();
            var configuration = componentContext.Resolve<IConfiguration>();
            var dbContextOptions = new DbContextOptions<TContext>(new Dictionary<Type, IDbContextOptionsExtension>());
            var optionsBuilder = new DbContextOptionsBuilder<TContext>(dbContextOptions)
                .UseApplicationServiceProvider(serviceProvider)
                .UseSqlServer(configuration.GetConnectionString("MyConnectionString"),
                    serverOptions => serverOptions.EnableRetryOnFailure(5, TimeSpan.FromSeconds(30), null));
            return optionsBuilder.Options;
        }).As<DbContextOptions<TContext>>()
        .InstancePerLifetimeScope();
    builder.Register(context => context.Resolve<DbContextOptions<TContext>>())
        .As<DbContextOptions>()
        .InstancePerLifetimeScope();
    builder.RegisterType<TContext>()
        .AsSelf()
        .InstancePerLifetimeScope();
}
  [1]: https://github.com/aspnet/EntityFrameworkCore/blob/40c8dbe9d45aa161a912345539675e77d114979d/src/EFCore/Extensions/EntityFrameworkServiceCollectionExtensions.cs#L476-L500
