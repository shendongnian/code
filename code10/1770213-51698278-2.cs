    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    public partial class PlayList
    {
        [JsonProperty("totalResults")]
        public long TotalResults { get; set; }
        [JsonProperty("resultsPerPage")]
        public long ResultsPerPage { get; set; }
        
        [JsonProperty("nextPageToken")]
        public string NextPageToken { get; set; }
        [JsonProperty("currentResults")]
        public long CurrentResults { get; set; }
        [JsonProperty("items")]
        public Dictionary<string, Item> Items { get; set; }
        [JsonProperty("status")]
        public bool Status { get; set; }
    }
    public partial class Item
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
        public override string ToString() {
           return string.Format("{0} -> {1}", Id, Title);
        }
    }
    public partial class PlayList
    {
        public static PlayList FromJson(string json) => JsonConvert.DeserializeObject<PlayList>(json, Converter.Settings);
    }
    public static class Serialize
    {
        public static string ToJson(this PlayList self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }
    internal static class Converter
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
