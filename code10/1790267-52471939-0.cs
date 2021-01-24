    // To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
    //
    //    using QuickType;
    //
    //    var data = Data.FromJson(jsonString);
    
    namespace QuickType
    {
        using System;
        using System.Collections.Generic;
    
        using System.Globalization;
        using Newtonsoft.Json;
        using Newtonsoft.Json.Converters;
    
        public partial class Data
        {
            [JsonProperty("Date and Time")]
            public DateAndTime[] DateAndTime { get; set; }
    
            [JsonProperty("How to Videos")]
            public DateAndTime[] HowToVideos { get; set; }
    
            [JsonProperty("My Timesheets And Schedule")]
            public DateAndTime[] MyTimesheetsAndSchedule { get; set; }
        }
    
        public partial struct DateAndTime
        {
            public bool? Bool;
            public long? Integer;
            public string String;
    
            public static implicit operator DateAndTime(bool Bool) => new DateAndTime { Bool = Bool };
            public static implicit operator DateAndTime(long Integer) => new DateAndTime { Integer = Integer };
            public static implicit operator DateAndTime(string String) => new DateAndTime { String = String };
        }
    
        public partial class Data
        {
            public static Data FromJson(string json) => JsonConvert.DeserializeObject<Data>(json, QuickType.Converter.Settings);
        }
    
        public static class Serialize
        {
            public static string ToJson(this Data self) => JsonConvert.SerializeObject(self, QuickType.Converter.Settings);
        }
    
        internal static class Converter
        {
            public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
            {
                MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                DateParseHandling = DateParseHandling.None,
                Converters = {
                    DateAndTimeConverter.Singleton,
                    new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
                },
            };
        }
    
        internal class DateAndTimeConverter : JsonConverter
        {
            public override bool CanConvert(Type t) => t == typeof(DateAndTime) || t == typeof(DateAndTime?);
    
            public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
            {
                switch (reader.TokenType)
                {
                    case JsonToken.Integer:
                        var integerValue = serializer.Deserialize<long>(reader);
                        return new DateAndTime { Integer = integerValue };
                    case JsonToken.Boolean:
                        var boolValue = serializer.Deserialize<bool>(reader);
                        return new DateAndTime { Bool = boolValue };
                    case JsonToken.String:
                    case JsonToken.Date:
                        var stringValue = serializer.Deserialize<string>(reader);
                        return new DateAndTime { String = stringValue };
                }
                throw new Exception("Cannot unmarshal type DateAndTime");
            }
    
            public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
            {
                var value = (DateAndTime)untypedValue;
                if (value.Integer != null)
                {
                    serializer.Serialize(writer, value.Integer.Value);
                    return;
                }
                if (value.Bool != null)
                {
                    serializer.Serialize(writer, value.Bool.Value);
                    return;
                }
                if (value.String != null)
                {
                    serializer.Serialize(writer, value.String);
                    return;
                }
                throw new Exception("Cannot marshal type DateAndTime");
            }
    
            public static readonly DateAndTimeConverter Singleton = new DateAndTimeConverter();
        }
    }
