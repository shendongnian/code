    class BaseClass
    {
        [JsonProperty("type")]
        public string EntityType
        { get; set; }
    }
    class A : BaseClass
    {
        public int abc { get; set; }
    }
    class B : BaseClass
    {
        public int cde { get; set; }
    }
