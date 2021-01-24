    public class Example
    {
        public string StringData { get; set; }
    
        public ComplexData ComplexData { get; set; }
    
        public string Type { get; set; }
    }
    
    public class ComplexData
    {
        public string Name { get; set; }
    
        [JsonProperty("19")]
        public Foo Nineteen { get; set; }
    
        [JsonProperty("21")]
        public Foo TwentyOne { get; set; }
    }
    
    public class Foo
    {
        public string Owner { get; set; }
    }
    
    public class FlexibleJsonConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var examples = new List<Example>();
            var obj = JObject.Load(reader);
            foreach (var exampleJson in obj["examples"])
            {
                var example = new Example { Type = (string)exampleJson["type"] };
                if (example.Type == "complex")
                {
                    example.ComplexData = exampleJson["data"].ToObject<ComplexData>();
                }
                else
                {
                    example.StringData = (string)exampleJson["data"];
                }
    
                examples.Add(example);
            }
    
            return examples.ToArray();
        }
    
        public override bool CanConvert(Type objectType)
        {
            return objectType.IsAssignableFrom(typeof(Example[]));
        }
    }
    
    private static void Main()
    {
        var json = @"{
                        ""examples"": [{
                                ""data"": ""String data"",
                                ""type"": ""foo""
                            }, {
                                ""data"": {
                                    ""name"": ""Complex data"",
                                    ""19"": {
                                        ""owner"": ""Paarthurnax""
                                    }
                                },
                                ""type"": ""complex""
                            }, {
                                ""data"": {
                                    ""name"": ""Differently complex data"",
                                    ""21"": {
                                        ""owner"": ""Winking Skeever""
                                    }
                                },
                                ""type"": ""complex""
                            }
                        ]
                    }";
    
        var examples = JsonConvert.DeserializeObject<IEnumerable<Example>>(json, new FlexibleJsonConverter());
    
        foreach (var example in examples)
        {
            Console.WriteLine($"{example.Type}: {example.StringData ?? example.ComplexData.Nineteen?.Owner ?? example.ComplexData.TwentyOne.Owner}");
        }
    
        Console.ReadKey();
    }
