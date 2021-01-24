    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApp11
    {
        class Program
        {
            static void Main(string[] args)
            {
                var js = "{\"amounts\": [ { \"tid\": 7072, \"amount\": 10000, \"currency\": \"USD\"        },        {            \"tid\": 7072,            \"amount\": 4000,            \"currency\": \"USD\"        }    ],    \"status\": 0,    \"errorCode\": 0}";
                var obj = Welcome.FromJson(js);
                for (int i = 0; i < obj.Amounts.Length; i++)
                {
                    obj.Amounts[i].AmountAmount /= 10;
                }
                var newjs = Serialize.ToJson(obj);
                Console.WriteLine(newjs);
                Console.ReadKey();
    
            }
        }
    
        public partial class Welcome
        {
            [JsonProperty("amounts")]
            public Amount[] Amounts { get; set; }
    
            [JsonProperty("status")]
            public long Status { get; set; }
    
            [JsonProperty("errorCode")]
            public long ErrorCode { get; set; }
        }
    
        public partial class Amount
        {
            [JsonProperty("tid")]
            public long Tid { get; set; }
    
            [JsonProperty("amount")]
            public long AmountAmount { get; set; }
    
            [JsonProperty("currency")]
            public string Currency { get; set; }
        }
    
        public partial class Welcome
        {
            public static Welcome FromJson(string json) => JsonConvert.DeserializeObject<Welcome>(json, Converter.Settings);
        }
    
    
    
        public static class Converter
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
    
        public static class Serialize
        {
            public static string ToJson(this Welcome self)
            {
                return JsonConvert.SerializeObject(self, Converter.Settings);
            }
        }
    
    }
