    using System;
    using System.IO;
    using Newtonsoft.Json;
    
    public class Organization
    {
        [JsonProperty("token")]
        public string Token { get; set; }
        
        [JsonProperty("@version")]
        public string Version { get; set; }
        
        [JsonProperty("key")]
        public string Key { get; set; }
        
        [JsonProperty("result")]
        public string[][] Results { get; set; }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            string json = File.ReadAllText("test.json");
            var org = JsonConvert.DeserializeObject<Organization>(json);
            Console.WriteLine($"Token: {org.Token}");
            Console.WriteLine($"Version: {org.Version}");
            Console.WriteLine($"Key: {org.Key}");
            Console.WriteLine("Result entries:");
            foreach (string[] entry in org.Results)
            {
                Console.WriteLine(string.Join(", ", entry));
            }
        }
    }
