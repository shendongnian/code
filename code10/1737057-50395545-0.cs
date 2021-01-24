    public class AdminController<T> : Controller
    {
        private readonly T _repo;
        public AdminController(T repo)
        {
            _repo = repo;
        }
    
        ...
    }
    
    services.AddScoped<AdminController<IRepository>>(c => {
        Console.WriteLine("We need you");
        return new AdminController<IRepository>(c.GetService<IRepository>());
    });
