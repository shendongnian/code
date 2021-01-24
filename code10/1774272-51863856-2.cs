    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    
    namespace ConsoleApp1
    {
    
        public interface IFirebaseObject
        {
            string FirebaseId { get; set; }
        }
    
        public class PoolData
        {
            public string FirebaseId { get; set; }
            public string Alias { get; set; }
            public string Address { get; set; }
            [JsonConverter(typeof(MapToArrayConverter<Alarm>))]
            public List<Alarm> Alarms { get; set; }
        }
    
        public class Alarm: IFirebaseObject
        {
            public string FirebaseId { get; set; }
            public Threshold Threshold { get; set; } //object
        }
    
        public class Threshold
        {
            public int Value { get; set; }
        }
    
        class Origin
        {
            public Dictionary<string, PoolData> PoolDatas { get; set; }
        }
    
        class Destination
        {
            public PoolData[] PoolDatas { get; set; }
        }
    
    
        class Program
        {
            static void Main(string[] args)
            {
                string json = File.ReadAllText("data.json");
                var data = JsonConvert.DeserializeObject<Origin>(json);
                var destination = new Destination();
                destination.PoolDatas = data.PoolDatas.Select(i =>
                {
                    i.Value.FirebaseId = i.Key;
                    return i.Value;
                }).ToArray();
            }
        }
    
    
        public class MapToArrayConverter<T> : JsonConverter where T : IFirebaseObject
        {
            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                if (reader.TokenType == JsonToken.StartObject)
                {
                    JObject item = JObject.Load(reader);
                    Dictionary<string, T> value = JsonConvert.DeserializeObject<Dictionary<string, T>>(item.ToString());
                    // TODO also consider single values instead of lists
                    return value.Select(i =>
                    {
                        i.Value.FirebaseId = i.Key;
                        return i.Value;
                    }).ToList();
                } else
                {
                    return null;
                }
            }
    
            public override bool CanConvert(Type objectType)
            {
                // TODO validate the object type
                return true;
            }
    
            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                // TODO implement the reverse method to also write
                throw new NotImplementedException();
            }
        }
    }
