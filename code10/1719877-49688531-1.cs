    // To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
    //
    //    using QuickType;
    //
    //    var welcome = Welcome.FromJson(jsonString);
    
    namespace QuickType
    {
        using System;
        using System.Collections.Generic;
    
        using System.Globalization;
        using Newtonsoft.Json;
        using Newtonsoft.Json.Converters;
    
        public partial class Welcome
        {
            [JsonProperty("32")]
            public The32 The32 { get; set; }
        }
    
        public partial class The32
        {
            [JsonProperty("name")]
            public string Name { get; set; }
    
            [JsonProperty("data")]
            public Data Data { get; set; }
        }
    
        public partial class Data
        {
            [JsonProperty("value")]
            public object Value { get; set; }
    
            [JsonProperty("type")]
            public string Type { get; set; }
    
            [JsonProperty("supported")]
            public Security Supported { get; set; }
    
            [JsonProperty("version")]
            public Version Version { get; set; }
    
            [JsonProperty("security")]
            public Security Security { get; set; }
    
            [JsonProperty("invalidateTime")]
            public long InvalidateTime { get; set; }
    
            [JsonProperty("updateTime")]
            public long UpdateTime { get; set; }
        }
    
        public partial class Security
        {
            [JsonProperty("value")]
            public bool Value { get; set; }
    
            [JsonProperty("type")]
            public string Type { get; set; }
    
            [JsonProperty("invalidateTime")]
            public long InvalidateTime { get; set; }
    
            [JsonProperty("updateTime")]
            public long UpdateTime { get; set; }
        }
    
        public partial class Version
        {
            [JsonProperty("value")]
            public long Value { get; set; }
    
            [JsonProperty("type")]
            public string Type { get; set; }
    
            [JsonProperty("invalidateTime")]
            public long InvalidateTime { get; set; }
    
            [JsonProperty("updateTime")]
            public long UpdateTime { get; set; }
        }
    
        public partial class Welcome
        {
            public static Welcome FromJson(string json) => JsonConvert.DeserializeObject<Welcome>(json, QuickType.Converter.Settings);
        }
    
        public static class Serialize
        {
            public static string ToJson(this Welcome self) => JsonConvert.SerializeObject(self, QuickType.Converter.Settings);
        }
    
        internal class Converter
        {
            public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
            {
                MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                DateParseHandling = DateParseHandling.None,
                Converters = { 
                    new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
                },
            };
        }
    }
