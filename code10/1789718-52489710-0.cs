    [Test]
    public void InjectCertainRegistration()
    {
        // Arrange 
        var registry = new Registry();
        // Act
        var facade = registry.GetFacade();
        // Assert
        Assert.IsInstanceOf<AgentRepository>(facade.AgentRepository);
        Assert.IsInstanceOf<CustomerRepository>(facade.CustomerRepository);
    }
    // IoC registration
    public class Registry
    {
        private readonly IContainer _root;
        public Registry()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<HostManager>().As<IHost>().SingleInstance();
            builder.RegisterType<AgentRepository>().As<IRepository>().Named<IRepository>("Agent").PreserveExistingDefaults();
            builder.RegisterType<CustomerRepository>().Named<IRepository>("Customer");
            builder.RegisterType<ToDoFacade>().As<IFacade>()
                .WithParameter(new ResolvedParameter((p, ctx) => p.Name == "agentRepository",
                    (p, ctx) => ctx.ResolveNamed<IRepository>("Agent")))
                .WithParameter(new ResolvedParameter((p, ctx) => p.Name == "customerRepository",
                    (p, ctx) => ctx.ResolveNamed<IRepository>("Customer")));
            _root = builder.Build();
        }
        public IFacade GetFacade()
        {
            return _root.Resolve<IFacade>();
        }
    }
    public class ToDoFacade : IFacade
    {
        /// <summary>
        /// Just for testing
        /// </summary>
        public IRepository AgentRepository { get; }
        /// <summary>
        /// Just for testing
        /// </summary>
        public IRepository CustomerRepository { get; }
        public ToDoFacade(IHost host, IRepository agentRepository, IRepository customerRepository)
        {
            AgentRepository = agentRepository;
            CustomerRepository = customerRepository;
        }
    }
    public class CustomerRepository : IRepository
    {
        public CustomerRepository()
        {
        }
    }
    public class AgentRepository : IRepository
    {
        public AgentRepository()
        {
        }
    }
    public interface IFacade
    {
        /// <summary>
        /// Just for testing
        /// </summary>
        IRepository AgentRepository { get; }
        /// <summary>
        /// Just for testing
        /// </summary>
        IRepository CustomerRepository { get; }
    }
    public class HostManager : IHost
    {
        public HostManager()
        {
        }
    }
    public interface IHost { }
    public interface IRepository { }
