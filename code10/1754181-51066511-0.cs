    class Program
    {
        static void Main(String[] args)
        {
            var str1 = "{\"players\":[{\"player_id\":\"331574\",\"team_id\":\"95\",},{\"player_id\":\"331575\",\"team_id\":\"95\",}],\"coach\":{\"id\":\"249197\",\"first_name\":\"Guillermo\",}}";
            var obj1 = JsonConvert.DeserializeObject<Squad>(str1);
    
            var str2 = "{\"players\":[{\"player_id\":\"331574\",\"team_id\":\"95\",},{\"player_id\":\"331575\",\"team_id\":\"95\",}],\"coach\":[]}";
            var obj2 = JsonConvert.DeserializeObject<Squad>(str2);
        }
    }
    
    public class Squad
    {
        public List<Player> players { get; set; }
    
        [JsonProperty("coach")]
        [JsonConverter(typeof(SingleOrArrayConverter<Coach>))]
        public List<Coach> coach { get; set; }
        public class Coach
        {
            public int id { get; set; }
            public string first_name { get; set; }
        }
    
        public class Player
        {
            public int player_id { get; set; }
            public int team_id { get; set; }
        }
    }
    class SingleOrArrayConverter<T> : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(List<T>));
        }
    
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JToken token = JToken.Load(reader);
            if (token.Type == JTokenType.Array)
            {
                return token.ToObject<List<T>>();
            }
            return new List<T> { token.ToObject<T>() };
        }
    
        public override bool CanWrite
        {
            get { return false; }
        }
    
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
