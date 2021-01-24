    public ValuesController : Controller
    {
        private readonly DbModel _db;
    
        public ValuesController(DbModel db)
        {
            _db = db;
        }
    }
