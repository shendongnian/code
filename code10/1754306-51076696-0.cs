        using System;
        using System.Collections.Generic;
    
        using System.Globalization;
        using Newtonsoft.Json;
        using Newtonsoft.Json.Converters;
    
        public partial class JsonModel
        {
            [JsonProperty("FirstName")]
            public string FirstName { get; set; }
    
            [JsonProperty("LastName")]
            public string LastName { get; set; }
    
            [JsonProperty("Country")]
            public string Country { get; set; }
    
            [JsonProperty("CityOrTown")]
            public string CityOrTown { get; set; }
    
            [JsonProperty("Line1")]
            public string Line1 { get; set; }
    
            [JsonProperty("PostalCode")]
            public string PostalCode { get; set; }
    
            [JsonProperty("BirthDay")]
            public string BirthDay { get; set; }
    
            [JsonProperty("BirthMonth")]
            public string BirthMonth { get; set; }
    
            [JsonProperty("BirthYear")]
    
            public string BirthYear { get; set; }
        }
