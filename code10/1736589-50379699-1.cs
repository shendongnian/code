    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    
    namespace Test
    {
        public class Program
        {
            static void Main(string[] args)
            {
                var json = 
                    @"{
                      ""id"": ""12345"",
                      ""custom_fields"": [
                          {
                            ""definition"": ""field1"",
                            ""value"": ""stringvalue""
                          }, {
                            ""definition"": ""field2"",
                            ""value"": [ ""arrayvalue1"", ""arrayvalue2"" ]
                          }, {
                            ""definition"": ""field3"",
                            ""value"": {
                              ""type"": ""user"",
                              ""id"": ""1245""
                            }
                          }
                        ]
                    }";
    
                var rootObject = JsonConvert.DeserializeObject<RootObject>(json);
                
                Console.WriteLine(JsonConvert.SerializeObject(rootObject));
            }
        }
    
        public class RootObject
        {
            [JsonProperty(PropertyName = "id")]
            public string Id { get; set; }
            
            [JsonProperty(PropertyName = "custom_fields")]
            public List<CustomField> CustomFields { get; set; }
        }
    
        public class CustomField
        {
            [JsonProperty(PropertyName = "definition")]
            public string Definition { get; set; }
            
            [JsonProperty(PropertyName = "value")]
            [JsonConverter(typeof(CustomValueConverter))]
            public dynamic Value { get; set; }
        }
    
        public class CustomValueConverter : JsonConverter
        {
            // By returning false, we let the default `WriteJson` kick in
            public override bool CanWrite => false;
            
            public override bool CanConvert(Type objectType) 
            {
                return true;
            }
    
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.Null)
                {
                    return string.Empty;
                } 
                
                if (reader.TokenType == JsonToken.String)
                {
                    return serializer.Deserialize<string>(reader);
                }
    
                if (reader.TokenType == JsonToken.StartArray)
                {
                    return serializer.Deserialize<string[]>(reader);
                }
                
                return serializer.Deserialize<Dictionary<string, string>>(reader);
            }
            
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                throw new NotImplementedException();
            }
        }
    }
