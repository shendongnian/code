    [Test]
    public void AutofacLifetimeScope()
    {
        // Arrange
        var builder = new ContainerBuilder();
        builder.RegisterType<Job>();
        builder.RegisterType<AnotherService>();
        builder.RegisterType<SomeService>();
        builder.RegisterType<Repository>().InstancePerLifetimeScope().WithProperty(ResolvedParameter.ForKeyed<Option>("opt"));
            
        var container = builder.Build();
        // Act
        Job job1;
        var option1 = new Option {ConnectinString = "DE Connection"};
        using (var scope = container.BeginLifetimeScope(c => c.RegisterInstance(option1).Keyed<Option>("opt")))
        {
            job1 = scope.Resolve<Job>();
        }
        Job job2;
        var option2 = new Option { ConnectinString = "AT Connection" };
        using (var scope = container.BeginLifetimeScope(c => c.RegisterInstance(option2).Keyed<Option>("opt")))
        {
            job2 = scope.Resolve<Job>();
        }
        //Assert
        Assert.AreEqual(job1.SomeService.Repository.PriceListConfig, option1);
        Assert.AreEqual(job1.AnotherService.Repository.PriceListConfig, option1);
        Assert.AreEqual(job2.SomeService.Repository.PriceListConfig, option2);
        Assert.AreEqual(job2.AnotherService.Repository.PriceListConfig, option2);
    }
    public class Repository
    {
        public Option PriceListConfig { get; set; }
    }
    public class Option
    {
        public string ConnectinString { get; set; }
        public string Country { get; set; }
        public string ExecutionTime { get; set; }
    }
    public class Job
    {
        public SomeService SomeService { get; }
        public AnotherService AnotherService { get; }
        public Job(SomeService someService, AnotherService anotherService)
        {
            SomeService = someService;
            AnotherService = anotherService;
        }
    }
    public class AnotherService
    {
        public Repository Repository { get; }
        public AnotherService(Repository repository)
        {
            Repository = repository;
        }
    }
    public class SomeService
    {
        public Repository Repository { get; }
        public SomeService(Repository repository)
        {
            Repository = repository;
        }
    }
