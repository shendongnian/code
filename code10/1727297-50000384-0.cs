    public class DataController : ApiController {
        public string data { get; set; }
    
        public DataController() : base() { }
    
        public DataController(string analyticsData) {
            data = analyticsData;
        }
        //other code
    }
