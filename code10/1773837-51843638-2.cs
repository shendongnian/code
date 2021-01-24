    public class MyService : IMyService
    {
        readonly MyDbContext _context;
    
        public MyService(MyDbContext context)
        {
            _context = context;
        }
        public void DoSomeWork()
        {
            //Now you can use the context here
        }
    }
    public interface IMyService
    {
        void DoSomeWork();
    }
    
    public class MyController : Controller
    {
        readonly IMyService _myService;;
    
        public MyController(IMyService myService)
        {
            _myService = myService;
        }
    }
    
    //In your ConfigureServices method
    services.AddDbContext<myContext>(options =>
    {
        options.UseSqlServer(Configuration.GetConnectionString("myContextConexionString"));
    });
    services.AddScoped<IMyService, MyService>();
