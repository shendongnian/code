    public abstract class BaseODataController<T> : ODataController
        where T : class
    {
        protected readonly ApplicationDbContext _db;
    
        public BaseODataController(ApplicationDbContext db)
        {
            _db = db;
        }
    }
    public class FooController : BaseODataController<Foo>
    {
        public FooController(ApplicationDbContext context)
            : base(context)
        {
        }
    }
