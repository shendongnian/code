    public class Startup
    {
    
       public void ConfigureServices(IServiceCollection services)
       {
    
        //Add Dependencies
        services.AddTransient<IProductRepository, ProductRepository>();
        //configure DI for IMemoryCache and CachingEngine
        services.AddTransient<IMemoryCache, MyMemoryCacheClass>();
        services.AddTransient<MyICachingEngineInterface, CachingEngine>();
    
        //Extention method that sets up the shared objects used in MVC apps
        services.AddMvc();
        services.AddMemoryCache();
        ....
       }
    }
    public class MainController : Controller
    {
        private readonly ICachingEngine _engine;
        public MainController(ICachingEngine engine)
        {
            _engine = engine;
        }
        public IActionResult Index()
        {
            var products = CachingEngine.GetProducts();
            ....
        }
    }
