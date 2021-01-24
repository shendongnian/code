    public class RepositoryA : IRepositoryA
    {
        private readonly Context _context;
        public RepositoryA(Context context)
        {
            _context = context;
        }
        public List<CLASS> GetA(int id)
        {
            return _context.GetByID(id);
        }
    }
    public interface IRepositoryA
    {
        List<CLASS> GetA(int id);
    }
    public class RepositoryB : IRepositoryB
    {
        private readonly Context _context;
        public RepositoryB(Context context)
        {
            _context = context;
        }
        public List<CLASS> GetB(int id)
        {
            return _context.GetByID(id);
        }
    }
    public interface IRepositoryB
    {
        List<CLASS> GetB(int id);
    }
    public class Controller
    {
        private IService _service;
        public Controller(IService service)
        {
            _service = service;
        }
        public ActionResult METHOD(int id)
        {
            //do something with both RepositoryA and RepositoryB THROUGH the service. The service needs to hold the business rules, and repositories should only care about querying data and handling contexts.
            var data = _service.DoSomethingWithRepoAandB(id)
            return View(data);
        }
    }
    public class Service : IService
    {
        private IRepositoryA _a;
        private IRepositoryB _b;
        // Pass Mock Repositories in unit tests -> PS: You can't have 2 constructors if you're using dependency injection.
        public Service(RepositoryA a, RepositoryB b)
        {
            _a = a;
            _b = b;
        }
        public void DoSomethingWithRepoAandB(int id)
        {
            var something = _a.GetA(id);
            var otherThing = _b.GetB(id);
        }
    }
    public interface IService
    {
        void DoSomethingWithRepoAandB(int id);
    }
    public class Bootstrapper
    {
        //this class should be in a separated assembly, responsible for handling the dependency injection. Using Simple Injection syntax just as an example
        public static void RegisterServices(Container container) //IoC Container
        {
            container.Register<IService, Service>(Lifestyle.Scoped);
            container.Register<IRepositoryA, RepositoryA>(Lifestyle.Scoped);
            container.Register<IRepositoryB, RepositoryB>(Lifestyle.Scoped);
            container.Register<Context>(() => {
                var options = // Configure your ContextOptions here
                return new Context(options);
            });
        }
    }
    public class Startup
    {
        //This is your startup configuration if you're using WebApi. If you're on MVC, you can do this on your Global.asax
        public void Configuration()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle(); 
            BootStrapper.RegisterServices(container);
        }
    }
