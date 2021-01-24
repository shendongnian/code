    namespace JSON
    {
        using System;
        using System.Collections.Generic;
    
        using System.Globalization;
        using Newtonsoft.Json;
        using Newtonsoft.Json.Converters;
    
        public partial class Root
        {
            [DefaultValue("")]
            [JsonProperty("allOrNone")]
            public bool AllOrNone { get; set; }
    
            [DefaultValue("")]
            [JsonProperty("records")]
            public Record[] Records { get; set; }
        }
    
        public partial class Record
        {
            [DefaultValue("")]
            [JsonProperty("Address__c")]
            public string AddressC { get; set; }
    
            [DefaultValue("")]
            [JsonProperty("ConsentToComm__c")]
            public string ConsentToCommC { get; set; }
    
            [DefaultValue("")]
            [JsonProperty("EmailCLDate__c")]
            public string EmailClDateC { get; set; }
    
            [DefaultValue("")]
            [JsonProperty("attributes")]
            public Attributes Attributes { get; set; }
        }
    
        public partial class Attributes
        {
            [DefaultValue("")]
            [JsonProperty("type")]
            public string Type { get; set; }
        }
    
        public partial class Root
        {
            public static Root FromJson(string json) => JsonConvert.DeserializeObject<Root>(json, QuickType.Converter.Settings);
        }
    
        public static class Serialize
        {
            public static string ToJson(this Root self) => JsonConvert.SerializeObject(self, QuickType.Converter.Settings);
        }
    
        internal static class Converter
        {
            public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = ShouldSerializeContractResolver.Instance,
                MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                DateParseHandling = DateParseHandling.None,
                Converters = {
                    new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
                },
            };
        }
    }
