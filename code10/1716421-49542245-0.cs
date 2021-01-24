    public class RootObject {
        public Data data { get; set; }
    }
    
    public class Data {
        public List<CoverageOption> coverageOptions { get; set; }
        //If you want to include the other properties, uncomment the lines below:
        //public List<string> errorMessages { get; set; }
        //public bool success { get; set; }
    }
    
    public class CoverageOption {
        public decimal premiumAnnual { get; set; }
    }
