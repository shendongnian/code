    public class ValuesController : Controller
    {
        private readonly IConfiguration _config;
        public ValuesController(IConfiguration config)
        {
            _config = config;
        }
        [HttpGet]
        public IEnumerable<string> Get()
        {
            MyDal dal = new MyDal(_config.GetConnectionString("conn"));
            return dal.GetSomeData();
        }
    }
