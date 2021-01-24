    public class HomeController : Controller
    {
        private readonly DataAccess da;// = new DataAccess() { };
        //private readonly DatabaseContext db;   
        public HomeController(DataAccess da)
        {
            this.da = da;
        } 
    }
    
    public class DataAccess
    {
        private readonly DatabaseContext db;     
        public DataAccess(DatabaseContext db)
        {
            this.db = db;
        }
    }
