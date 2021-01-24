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
            [JsonProperty("toasts", NullValueHandling = NullValueHandling.Ignore)]
            public Toast[] Toasts { get; set; }
        }
    
        public partial class Toast
        {
            [JsonProperty("total_count", NullValueHandling = NullValueHandling.Ignore)]
            public long? TotalCount { get; set; }
    
            [JsonProperty("count", NullValueHandling = NullValueHandling.Ignore)]
            public long? Count { get; set; }
    
            [JsonProperty("auth_toast", NullValueHandling = NullValueHandling.Ignore)]
            public bool? AuthToast { get; set; }
    
            [JsonProperty("items", NullValueHandling = NullValueHandling.Ignore)]
            public Item[] Items { get; set; }
        }
    
        public partial class Item
        {
            [JsonProperty("uid", NullValueHandling = NullValueHandling.Ignore)]
            public long? Uid { get; set; }
    
            [JsonProperty("user", NullValueHandling = NullValueHandling.Ignore)]
            public User User { get; set; }
    
            [JsonProperty("like_id", NullValueHandling = NullValueHandling.Ignore)]
            public long? LikeId { get; set; }
    
            [JsonProperty("like_owner", NullValueHandling = NullValueHandling.Ignore)]
            public bool? LikeOwner { get; set; }
    
            [JsonProperty("created_at", NullValueHandling = NullValueHandling.Ignore)]
            public string CreatedAt { get; set; }
        }
    
        public partial class User
        {
            [JsonProperty("uid", NullValueHandling = NullValueHandling.Ignore)]
            public long? Uid { get; set; }
    
            [JsonProperty("user_name", NullValueHandling = NullValueHandling.Ignore)]
            public string UserName { get; set; }
    
            [JsonProperty("first_name", NullValueHandling = NullValueHandling.Ignore)]
            public string FirstName { get; set; }
    
            [JsonProperty("last_name", NullValueHandling = NullValueHandling.Ignore)]
            public string LastName { get; set; }
    
            [JsonProperty("bio", NullValueHandling = NullValueHandling.Ignore)]
            public string Bio { get; set; }
    
            [JsonProperty("location", NullValueHandling = NullValueHandling.Ignore)]
            public string Location { get; set; }
    
            [JsonProperty("relationship", NullValueHandling = NullValueHandling.Ignore)]
            public string Relationship { get; set; }
    
            [JsonProperty("user_avatar", NullValueHandling = NullValueHandling.Ignore)]
            public string UserAvatar { get; set; }
    
            [JsonProperty("account_type", NullValueHandling = NullValueHandling.Ignore)]
            public string AccountType { get; set; }
    
            [JsonProperty("venue_details", NullValueHandling = NullValueHandling.Ignore)]
            public object[] VenueDetails { get; set; }
    
            [JsonProperty("brewery_details", NullValueHandling = NullValueHandling.Ignore)]
            public object[] BreweryDetails { get; set; }
        }
    
        public partial class Welcome
        {
            public static Welcome FromJson(string json) => JsonConvert.DeserializeObject<Welcome>(json, QuickType.Converter.Settings);
        }
    
        public static class Serialize
        {
            public static string ToJson(this Welcome self) => JsonConvert.SerializeObject(self, QuickType.Converter.Settings);
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
    }
