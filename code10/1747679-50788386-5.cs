    public class SomeController : Controller
    {
        private readonly BlexzWebDb_db;
        //the framework handles this
        public SomeController(BlexzWebDbdb db)
        {
            _db = db;
        }
        //etc.
