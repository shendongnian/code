    [JsonConverter(typeof(QueryExpressionConverter))]
    abstract class QueryExpression
    {
        public string Operator { get; set; }
    }
