    public class DataController : ApiController {
        public string data { get; set; }
    
        public DataController() : this("somedefaultvalue") { } //calls the parameter constructor with "somedefaultvalue"
    
        public DataController(string analyticsData) {
            data = analyticsData;
        }
        //other code
    }
