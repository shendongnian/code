    public class Repository: IRepository
    {
        public Repository(IDatabaseConnectionString databaseConnectionString)
        {
            _databaseConnectionString = databaseConnectionString;
        }
    }
    public class ServiceThatRequiresDatabase : IServiceThatRequiresDatabase
    {
        public ServiceThatRequiresDatabase(IRepository repository)
        {
            _repository = repository;
        }
    }
    // ...
    services.AddScoped<IRepository, Repository>();
    services.AddScoped<IServiceThatRequiresDatabase, ServiceThatRequiresDatabase>();
    public class HomeController : Controller
    {
        public HomeController(IServiceThatRequiresDatabase service)
        {
            _service = service;
        }
    }
