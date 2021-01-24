    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    public partial class ChildClasses
    {
        [JsonProperty("myNodes")]
        public List<MyNode> MyNodes { get; set; }
    }
    public partial class MyNode
    {
        [JsonProperty("param1")]
        public long Param1 { get; set; }
        [JsonProperty("param2")]
        public string Param2 { get; set; }
        [JsonProperty("param3")]
        public Param3Union Param3 { get; set; }
    }
    public partial class Param3Element
    {
        [JsonProperty("myItemA")]
        public string MyItemA { get; set; }
        [JsonProperty("myItemB")]
        public string MyItemB { get; set; }
        [JsonProperty("myItemC")]
        public string MyItemC { get; set; }
    }
    public partial class PurpleParam3
    {
        [JsonProperty("myParam3param")]
        public long MyParam3Param { get; set; }
    }
    public partial struct Param3Union
    {
        public List<Param3Element> Param3ElementArray;
        public PurpleParam3 PurpleParam3;
        public bool IsNull => Param3ElementArray == null && PurpleParam3 == null;
    }
    public partial class ChildClasses
    {
        public static ChildClasses FromJson(string json) => JsonConvert.DeserializeObject<ChildClasses>(json, QuickType.Converter.Settings);
    }
    public static class Serialize
    {
        public static string ToJson(this ChildClasses self) => JsonConvert.SerializeObject(self, QuickType.Converter.Settings);
    }
    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                new Param3UnionConverter(),
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
    internal class Param3UnionConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(Param3Union) || t == typeof(Param3Union?);
        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            switch (reader.TokenType)
            {
                case JsonToken.StartObject:
                    var objectValue = serializer.Deserialize<PurpleParam3>(reader);
                    return new Param3Union { PurpleParam3 = objectValue };
                case JsonToken.StartArray:
                    var arrayValue = serializer.Deserialize<List<Param3Element>>(reader);
                    return new Param3Union { Param3ElementArray = arrayValue };
            }
            throw new Exception("Cannot unmarshal type Param3Union");
        }
        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (Param3Union)untypedValue;
            if (value.Param3ElementArray != null)
            {
                serializer.Serialize(writer, value.Param3ElementArray); return;
            }
            if (value.PurpleParam3 != null)
            {
                serializer.Serialize(writer, value.PurpleParam3); return;
            }
            throw new Exception("Cannot marshal type Param3Union");
        }
    }`
