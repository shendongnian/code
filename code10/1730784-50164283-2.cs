    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class ApiMessage
    {
        public string Header { get; set; }
    
        public object Body { get; set; }
    }
