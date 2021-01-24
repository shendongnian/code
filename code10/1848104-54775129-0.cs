    public class ServiceThatRequiresDatabase : IServiceThatRequiresDatabase
    {
        public ServiceThatRequiresDatabase(IDatabaseConnectionString databaseConnectionString)
        {
            _databaseConnectionString = databaseConnectionString;
        }
    }
    // ...
    services.AddScoped<IServiceThatRequiresDatabase, ServiceThatRequiresDatabase>();
    public class HomeController : Controller
    {
        public HomeController(IServiceThatRequiresDatabase service)
        {
            _service = service;
        }
    }
