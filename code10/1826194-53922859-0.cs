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
                    // Print out education level objects
                    IEnumerable<JToken> educationLevels = root.SelectTokens("..educationLevel[*]").ToList();
                    Console.WriteLine("Education Levels: ");
                    Console.WriteLine(JsonConvert.SerializeObject(educationLevels, Formatting.Indented));
                    // Print out degree objects
                    IEnumerable<JToken> degrees = root.SelectTokens("..degree[*]").ToList();
                    Console.WriteLine("\nDegrees: ");
                    Console.WriteLine(JsonConvert.SerializeObject(degrees, Formatting.Indented));
                }
            }
        }
    }
