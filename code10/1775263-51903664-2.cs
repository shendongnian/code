    class ResultView
    {
        [JsonConverter(typeof(TolerantDictionaryItemConverter<IDictionary<string, string[][]>, string[][]>))]
        public Dictionary<string, string[][]> Result { get; set; }
    }
