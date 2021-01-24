public override IDependencyScope BeginScope()       
{           
    ISiteRepositoryFactory repositoryFactory = new SiteAspNetRepositoryFactory(Config);
    GameModelFactory factory = new GameModelFactory(
     repositoryFactory, LocaleProvider, Config, Authenticate);
    return new GameWebApiDependencyScope(factory);
}
And Root scope is initialized ones in Resolver constructor.
I may have fixed the problem, but this is not exactly, because exception is unstable.
