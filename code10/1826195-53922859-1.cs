    using System;
    using System.Linq;
    using System.Net;
    using System.Collections.Generic;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    namespace webclient {
        public static class Program {
            private static readonly string URL = "https://susanavet2.skolverket.se/api/1.1/infos?town=%C3%96rebro&educationLevel=grund&organisationForm=h%C3%B6gskoleutbildning&configuration=program";
            public static void Main() {
                // Setup Webclient
                using (WebClient wc = new WebClient()) {
                    // Download JSON string
                    string json = wc.DownloadString(URL);
                    // Get JToken root to parse JSON string
                    JToken root = JToken.Parse(json);
                    JToken content = root["content"];
                    foreach (JToken child in content.Children()) {
                        JToken educationContent = child["content"]["educationInfo"];
                        // Print out education level
                        JToken educationLevel = educationContent.SelectToken("educationLevel");
                        Console.WriteLine("\neducationLevel");
                        Console.WriteLine(JsonConvert.SerializeObject(educationLevel, Formatting.Indented));
                        // Print out degree
                        JToken degree = educationContent.SelectToken("degree");
                        Console.WriteLine("\ndegree");
                        Console.WriteLine(JsonConvert.SerializeObject(degree, Formatting.Indented));
                    }
                }
            }
        }
    }
