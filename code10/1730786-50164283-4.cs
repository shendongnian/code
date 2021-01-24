    [JsonObject(NamingStrategyType = typeof(CamelCaseNamingStrategy))]
    public class ApiMessage
    {
        public HeaderType Header { get; set; }
    
        public object Body { get; set; }
    }
