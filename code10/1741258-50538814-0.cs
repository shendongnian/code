    public interface ISomeService
    {
        Guid Id { get; }
    }
    public class SomeService : ISomeService
    {
        public Guid Id { get; }
        public SomeService()
        {
            Id = Guid.NewGuid();
        }
        
        public SomeService(Guid id)
        {
            Id = id;
        }
    }
    // Startup.cs:
    builder.RegisterType<SomeService>().As<ISomeService>().InstancePerLifetimeScope();
    // TestController.cs:
    [Route("api/[controller]")]
    public class TestController : Controller
    {
        private readonly IComponentContext _context;
        public TestController(IComponentContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Get()
        {
            var service = _context.Resolve<ISomeService>();
            return Ok(service.Id);
        }
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var service = _context.Resolve<ISomeService>(new NamedParameter("id", id));
            return Ok(service.Id);
        }
    }
    // GET http://localhost:5000/api/test/e0198f72-6337-4880-b608-68935122cdea
    // each and every response will be the same: e0198f72-6337-4880-b608-68935122cdea
    // GET http://localhost:5000/api/test
    // this way it responds with some random guid each time endpoint is called
