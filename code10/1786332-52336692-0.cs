     public class FooController : Controller
     {
         private IOptions<FooConfig> _config;
         public FooController(IOptions<FooConfig> config)
         {
             _config = config ?? throw new ArgumentNullException(nameof(config));
         }
         ...
     }
