    // some method early in your app's life cycle
    public Kernel BuildKernel()
    {
        var modules = new INinjectModule[] 
        {
            new LinqToSqlDataContextModule(), // just my L2S binding
            new WebModule(),
            new EventRegistrationModule()
        };
        return new StandardKernel(modules);
    }
    // in LinqToSqlDataContextModule.cs
    public class LinqToSqlDataContextModule
    {
        public override Load()
        {
            Bind<IRepository>().To<LinqToSqlRepository>();
        }
    }
