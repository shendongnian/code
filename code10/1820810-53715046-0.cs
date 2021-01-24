    var rules = new RulesEngineOutputCollection
    {
        ProbableRoles = JsonConvert.DeserializeObject<Result[]>(bodyString).Select(r => r.Data).ToList()
    };
    public class Result
    {
        [JsonProperty("Result")]
        public RulesEngineOutput Data { get; set; }
    }
