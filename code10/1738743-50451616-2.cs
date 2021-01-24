    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    
    namespace Question_Answer_Console_App
    {
        public class Program
        {
            public const string JsonResultString = @"{
                                                         ""status"": ""SUCCESS"",
                                                         ""message"": ""something"",
                                                         ""data"": {
                                                             ""trade_origin_iso3country"": ""GBR"",
                                                             ""countries"": {
                                                                 ""ARM"": ""Armenia"",
                                                                 ""BLR"": ""Belarus "",
                                                                 ""DNK"": ""Denmark"",
                                                                 ""GBR"": ""United Kingdom"",
                                                                 ""MCO"": ""Monaco""
                                                             }
                                                         }
                                                     }";
            [STAThread]
            static void Main(string[] args)
            {
                var jsonResult = JsonConvert.DeserializeObject<JsonResult>(JsonResultString);
    
                foreach (var keyValue in jsonResult.Data.Countries)
                    Console.WriteLine($"{keyValue.Key} : {keyValue.Value}");
    
                Console.Read();
            }
        }
    
        public class JsonResult
        {
            public string Status { get; set; }
            public string Message { get; set; }
            public JsonData Data { get; set; }
        }
    
        public class JsonData
        {
            [JsonProperty("trade_origin_iso3country")]
            public string TradeOriginIso3country { get; set; }
            public Dictionary<string, string> Countries { get; set; }
        }
    }
