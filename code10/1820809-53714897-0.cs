    public class RulesEngineOutput
    {
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("code")]
        public string Code { get; set; }
    }
    public class RulesEngineOutputResult
    {
        public RulesEngineOutput Result { get; set; }
    }
    public class RulesEngineOutputCollection
    {
        public IEnumerable<RulesEngineOutputResult> ProbableRoles { get; set; }
    }
