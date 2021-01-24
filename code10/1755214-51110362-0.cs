    class Program
    {
        static void Main(string[] args)
        {
            string json = "{\"foo\": \"bar\",\"pets\": {\"dog\": {\"name\": \"spot\",\"age\": \"3\"},\"cat\": {\"name\": \"wendy\",\"age\": \"2\"}}}";
            Foo content = JsonConvert.DeserializeObject<Foo>(json);
            Console.Read();
        }
    }
    public class PetObject
    {
       [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("age")]
        public string Age { get; set; }
    }
    public class Foo
    {
        [JsonProperty("foo")]
        public string FooStr { get; set; }
        [JsonProperty("pets")]
        public Dictionary<string, PetObject> Pets { get; set; }
    }
