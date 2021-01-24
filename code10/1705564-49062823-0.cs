    public class Vehicle
    {
        public class Value
        {
            public string Model { get; set; }
            public string Description { get; set; }
            public string ETag { get; set; }
        }
        public class RootObject
        {
            public List<Value> Value { get; set; }
        }
    }
