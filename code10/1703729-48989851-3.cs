    public class ViewTable
    {
        public int Id { get; set; }
        [JsonProperty(PropertyName = "rows", NamingStrategyType = typeof(DefaultNamingStrategy), ItemTypeNameHandling = TypeNameHandling.None, TypeNameHandling = TypeNameHandling.None)]
        public IEnumerable<IDictionary<string, object>> Rows { get; set; }
    }
