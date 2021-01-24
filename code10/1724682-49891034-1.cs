    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    
    namespace TinkeroonieCSharp
    {
        class UserJSON
        {
            [JsonProperty]
            public string id;
            [JsonProperty]
            public string name;
            [JsonProperty]
            public string symbol;
            [JsonProperty]
            public string rank;
            [JsonProperty]
            public string price_usd;
            [JsonProperty]
            public string price_btc;
            [JsonProperty]
            public string twenty_four_hour_volume_usd;
            [JsonProperty]
            public string market_cap_usd;
            [JsonProperty]
            public string available_supply;
            [JsonProperty]
            public string total_supply;
            [JsonProperty]
            public string max_supply;
            [JsonProperty]
            public string percent_change_1h;
            [JsonProperty]
            public string percent_change_24h;
            [JsonProperty]
            public string percent_change_7d;
            [JsonProperty]
            public string last_updated;
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                using (var webClient = new System.Net.WebClient())
                {
                    var json = webClient.DownloadString("https://api.coinmarketcap.com/v1/ticker/808coin/");
                    List<UserJSON> array = JsonConvert.DeserializeObject<List<UserJSON>>(json);
                    var name = array[0].name;
                    Console.WriteLine(name);
                }
            }
        }
    }
