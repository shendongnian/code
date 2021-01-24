    class A {
        public object B { get; set; }
        [JsonProperty(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
        public object C { get; set; } // this property should be camel cased
    }
