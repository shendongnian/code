    public class SomeController : Controller
    {
        private readonly BlexzWebDb _db;
        //the framework handles this
        public SomeController(BlexzWebDb db)
        {
            _db = db;
        }
        //etc.
