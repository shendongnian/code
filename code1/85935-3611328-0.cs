    public class Service : IService
    {
        [Dependency("Key")]
        public Int32 Value { get; set; }
    }
