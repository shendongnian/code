    // To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
    //
    //    using QuickType;
    //
    //    var data = Data.FromJson(jsonString);
    
    namespace QuickType
    {
        using System;
        using System.Collections.Generic;
    
        using Newtonsoft.Json;
        using Newtonsoft.Json.Converters;
    
        public partial class Data
        {
            [JsonProperty("d")]
            public Dictionary<string, string> D { get; set; }
        }
    
        public partial class Data
        {
            public static Data FromJson(string json) =>
                JsonConvert.DeserializeObject<Data>(json, QuickType.Converter.Settings);
        }
    
        public static class Serialize
        {
            public static string ToJson(this Data self) =>
                JsonConvert.SerializeObject(self, QuickType.Converter.Settings);
        }
    
        internal class Converter
        {
            public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
            {
                MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                DateParseHandling = DateParseHandling.None,
            };
        }
    }
