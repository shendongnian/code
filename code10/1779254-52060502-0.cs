    class Program
    {
        static void Main(string[] args)
        {
            var json = "... your api response";
            var data = JsonConvert.DeserializeObject<MyData>(json, new Converter());
            Console.WriteLine(data);
        }
    }
    class Converter : JsonConverter<List<Member>>
    {
        public override bool CanRead => true;
        public override List<Member> ReadJson(JsonReader reader, Type objectType, List<Member> existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var result = JToken.Load(reader).ToObject<IDictionary<string, Member>>();
            return result.Values.ToList();
        }
        public override void WriteJson(JsonWriter writer, List<Member> value, JsonSerializer serializer)
        {
            //maybe you also want to convert back
            throw new NotImplementedException();
        }
    }
    class MyData
    {
        [JsonProperty("otherdata")]
        string OtherData;
        [JsonProperty("members")]
        List<Member> Members;
    }
    class Member
    {
        [JsonProperty("joined_at")]
        long JoinedAt;
        [JsonProperty("account_id")]
        long AccountId;
    }
