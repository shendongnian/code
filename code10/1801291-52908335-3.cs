    public class Data
    {
        [JsonProperty("context")]
        public Context Context { get; set; }
        public Data(int id)
        {
            Context = new Context
            {
                Id = id
            };
        }
    }
    public class Context
    {
        [JsonProperty("id")]
        public int Id { get; set; }
    }
