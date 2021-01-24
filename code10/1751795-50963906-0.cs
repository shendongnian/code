    using System;
        using System.Collections.Generic;
    
        using System.Globalization;
        using Newtonsoft.Json;
        using Newtonsoft.Json.Converters;
    
        public partial class JsonModel
        {
            [JsonProperty("featured")]
            public Featured Featured { get; set; }
    
            [JsonProperty("categories")]
            public List<Category> Categories { get; set; }
        }
    
        public partial class Category
        {
            [JsonProperty("id")]
            public long Id { get; set; }
    
            [JsonProperty("title")]
            public string Title { get; set; }
    
            [JsonProperty("description")]
            public object Description { get; set; }
    
            [JsonProperty("position")]
            public long Position { get; set; }
    
            [JsonProperty("media")]
            public List<Featured> Media { get; set; }
        }
    
        public partial class Featured
        {
            [JsonProperty("id")]
            public long Id { get; set; }
    
            [JsonProperty("title")]
            public string Title { get; set; }
    
            [JsonProperty("description")]
            public string Description { get; set; }
    
            [JsonProperty("short_description")]
            public string ShortDescription { get; set; }
    
            [JsonProperty("rating_avg")]
            public long RatingAvg { get; set; }
    
            [JsonProperty("image")]
            public string Image { get; set; }
    
            [JsonProperty("category_media", NullValueHandling = NullValueHandling.Ignore)]
            public CategoryMedia CategoryMedia { get; set; }
        }
    
        public partial class CategoryMedia
        {
            [JsonProperty("position")]
            public long Position { get; set; }
    
            [JsonProperty("category_id")]
            public long CategoryId { get; set; }
    
            [JsonProperty("media_id")]
            public long MediaId { get; set; }
    
            [JsonProperty("id")]
            public long Id { get; set; }
        }
    }
