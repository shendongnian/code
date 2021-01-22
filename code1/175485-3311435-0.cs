    public class CsvResult<T> : ActionResult
    {
        public IEnumerable<T> Records { get; private set; }
        public CsvResult(IEnumerable<T> records)
        {
            Records = records;
        }
        public override void ExecuteResult(ControllerContext context)
        {
            var response = context.HttpContext.Response;
            response.ContentType = "text/csv";
            var engine = new FileHelperEngine(typeof(T));
            engine.WriteStream(response.Output, Records);
        }
    }
    [DelimitedRecord(",")] 
    public class Customer 
    {
        public int Id { get; set; }
        public string Name { get; set; }	     
    }
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var customers = new[]
            {
                new Customer { Id = 1, Name = "customer 1" },
                new Customer { Id = 2, Name = "customer 2" },
            };
            return new CsvResult<Customer>(customers);
        }
    }
