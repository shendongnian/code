    public abstract class BaseService
    {
        protected Foo Foo { get; set; }
        protected Bar Bar { get; set; }
    
        public BaseService(IServiceProvider provider)
        {
            Foo = provider.GetService<Foo>();
            Bar = provider.GetService<Bar>();
        }
    }
    public class Service : BaseService, IService
    {
        public Service(IOtherDependency otherDependency, IServiceProvider provider) : base(provider) { }
    
        public void Method()
        {
            var value = Bar.value;
            Foo.Do(value);
        }
    }
    
    public class SomeController : BaseController
    {
        private readonly IService _service;
    
        public SomeController(IService service)
        {
            _service = service;
        }
    
        public IActionResult Index()
        {
            //call method
            _service.Method();
        }
    }
