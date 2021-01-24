    [ElasticsearchType(Name = "ES6")]
    public class ES6
    {
        [Text]
        public string A { get; set; }
        [Keyword(Index = false)]
        public string B { get; set; }
    }
