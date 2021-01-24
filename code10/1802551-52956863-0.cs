    public class ErrorResponse
    {
        [JsonProperty("errors")]
        private readonly IDictionary<string, IList<Error>> _errors;
        public ErrorResponse()
        {
            _errors = new Dictionary<string, IList<Error>>();
        }
        //...
    }
