    namespace QuickType
    {
        using System;
        using System.Collections.Generic;
    
        using System.Globalization;
        using Newtonsoft.Json;
        using Newtonsoft.Json.Converters;
    
        public partial class ImageData
        {
            [JsonProperty("Template_Name")]
            public string TemplateName { get; set; }
    
            [JsonProperty("Page_Number")]
            public List<PageNumber> PageNumber { get; set; }
        }
    
        public partial class PageNumber
        {
            [JsonProperty("Page_Details")]
            public List<PageDetail> PageDetails { get; set; }
        }
    
        public partial class PageDetail
        {
            [JsonProperty("areaName")]
            public string AreaName { get; set; }
    
            [JsonProperty("coordinate")]
            public string Coordinate { get; set; }
        }
    }
