    using System;
    using System.Linq;
    using System.Net;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    namespace Example {
        public static class Program {
            private static readonly string URL = "https://susanavet2.skolverket.se/api/1.1/infos?town=%C3%96rebro&educationLevel=grund&organisationForm=h%C3%B6gskoleutbildning&configuration=program";
            public static void Main() {
                using (WebClient wc = new WebClient()) {
                    string json = wc.DownloadString(URL);
                    JToken root = JToken.Parse(json);
                    JToken content = root["content"];
                    foreach (JToken child in content.Children()) {
                        JToken educationContent = child["content"]["educationInfo"];
                        DisplayJSON(educationContent, "educationLevel");
                        DisplayJSON(educationContent, "degree");
                    }
                }
            }
            private static void DisplayJSON(JToken content, string key) {
                JToken filteredTokens = content.SelectToken(key);
                Console.WriteLine(key);
                Console.WriteLine(JsonConvert.SerializeObject(filteredTokens, Formatting.Indented));
            }
        }
    }
