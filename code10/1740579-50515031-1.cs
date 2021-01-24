    public class Root {
        public Request request { get; set; }
    }
    
    public class Request {
        public TestRequest TestRequest { get; set; }
    }
    
    public class TestRequest {
        public OrderID OrderID { get; set; }
        public string SecondCategory { get; set; }
    }
    
    public class OrderID {
        public string orderNumber { get; set; }
        public string category { get; set; }
    }
