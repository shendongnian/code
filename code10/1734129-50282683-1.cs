    class A 
    {
        [JsonProperty(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
        public object C { get; set; }
    }
