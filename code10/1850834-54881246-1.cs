    public class Countries
    {
        public string id { get; set; }
        public Dictionary<CountryVal, int> Data { get; set; }
    }
    
    public class Departments
    {
        public string id { get; set; }
    }
    
    public class RootObject
    {
        public Countries countries { get; set; }
        public Departments departments { get; set; }
    }
