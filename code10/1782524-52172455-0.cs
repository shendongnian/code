    [JsonObject]
    public class TableUpdateResponse : IAPIResponse
    {
        [JsonProperty("result")]
        public TableRow[] Records { get; set; }
    }
    
    [JsonDictionary(ItemConverterType = typeof(TableFieldOrStringConverter))]
    public class TableRow : Dictionary<string, TableField>
    {
    
    }
    
    [JsonObject]
    public class TableField
    {
        [JsonProperty("display_value")]
        public string DisplayValue { get; set; }
    
        [JsonProperty("value")]
        public string Value { get; set; }
    
        /// <summary>
        /// Applicable when the field references another record
        /// </summary>
        [JsonProperty("link")]
        public string Link { get; set; }
    }
