    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    public class GooglePlaceModel
    {
        [JsonProperty("predictions")]
        public List<Prediction> Predictions { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
    }
    public class Prediction
    {
        [JsonProperty("description")]
        public string Description { get; set; }
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("matched_substrings")]
        public List<MatchedSubstring> MatchedSubstrings { get; set; }
        [JsonProperty("place_id")]
        public string PlaceId { get; set; }
        [JsonProperty("reference")]
        public string Reference { get; set; }
        [JsonProperty("structured_formatting")]
        public StructuredFormatting StructuredFormatting { get; set; }
        [JsonProperty("terms")]
        public List<Term> Terms { get; set; }
        [JsonProperty("types")]
        public List<TypeElement> Types { get; set; }
    }
    public class MatchedSubstring
    {
        [JsonProperty("length")]
        public long Length { get; set; }
        [JsonProperty("offset")]
        public long Offset { get; set; }
    }
    public class StructuredFormatting
    {
        [JsonProperty("main_text")]
        public string MainText { get; set; }
        [JsonProperty("main_text_matched_substrings")]
        public List<MatchedSubstring> MainTextMatchedSubstrings { get; set; }
        [JsonProperty("secondary_text")]
        public string SecondaryText { get; set; }
    }
    public class Term
    {
        [JsonProperty("offset")]
        public long Offset { get; set; }
        [JsonProperty("value")]
        public string Value { get; set; }
    }
    public enum TypeElement { Geocode, StreetAddress };
    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters = {
                TypeElementConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
    internal class TypeElementConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(TypeElement) || t == typeof(TypeElement?);
        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "geocode":
                    return TypeElement.Geocode;
                case "street_address":
                    return TypeElement.StreetAddress;
            }
            throw new Exception("Cannot unmarshal type TypeElement");
        }
        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (TypeElement)untypedValue;
            switch (value)
            {
                case TypeElement.Geocode:
                    serializer.Serialize(writer, "geocode");
                    return;
                case TypeElement.StreetAddress:
                    serializer.Serialize(writer, "street_address");
                    return;
            }
            throw new Exception("Cannot marshal type TypeElement");
        }
        public static readonly TypeElementConverter Singleton = new TypeElementConverter();
    }
