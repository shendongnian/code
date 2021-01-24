    public class Unit
        {
            public string value { get; set; }
            public List<string> @enum { get; set; }
        }
    
        public class Temperature
        {
            public string dataType { get; set; }
            public Unit unit { get; set; }
            public int min { get; set; }
            public int max { get; set; }
            public string description { get; set; }
        }
    
        public class Variables
        {
            public Temperature temperature { get; set; }
        }
    
        public class RootObject
        {
            public string model { get; set; }
            public string make { get; set; }
            public List<string> alias { get; set; }
            public Variables variables { get; set; }
        }
