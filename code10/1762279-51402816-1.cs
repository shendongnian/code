    using Newtonsoft.Json;
    public class DerivedClass : BaseClass
    {
        public string Property1 { get; set; }
        public int Property2 { get; set; }
        [JsonIgnore]
        public int Property3 { get; set; }
    }
