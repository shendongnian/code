    public class MyModel
    {
        public string _id { get; set; }
        public IEnumerable<MyNestedModel> myArray { get; set; }
    }
    public class MyNestedModel
    {
        public string other { get; set; }
    }
