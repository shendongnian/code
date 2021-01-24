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
        private readonly MyICachingEngineInterface _cachingEngine;
        public MainController(MyICachingEngineInterface cachingEngine)
        {
            _cachingEngine = cachingEngine;
        }
        public IActionResult Index()
        {
            var products = _cachingEngine.GetProducts();
            ....
        }
    }
