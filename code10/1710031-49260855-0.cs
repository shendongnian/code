    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    namespace Example
    {
    public class SampleResponse1
    {
        [JsonProperty("zip_codes")]
        public string[] ZipCodes { get; set; }
       }
    }
