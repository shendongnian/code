    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApp14
    {
        class Program
        {
            class qualifier
            {
                public string name { get; set; }
                public string value { get; set; }
                public string code { get; set; }
                public string prefix { get; set; }
            }
    
            class Diagnosis
            {
                public string name { get; set; }
                public string code { get; set; }
                public string table { get; set; }
                public string addedby { get; set; }
                public string dateadded { get; set; }
                public qualifier[] Qualifier { get; set; }
                public string prefix { get; set; }
                public string suffix { get; set; }
                public string jsonString { get; set; }
            }
            static void Main(string[] args)
            {
                var json = @"
    [
        {
            ""name"": ""Test 2"",
            ""code"": ""398057008"",
            ""table"": ""SNOMEDCT"",
            ""addedby"": ""morgan.baxter"",
            ""dateadded"": 1544523489235,
            ""qualifier"": [
                {
                    ""name"": ""Qualifier"",
                    ""value"": ""Confirmed Diagnosis"",
                    ""code"": ""410605003"",
                    ""prefix"": ""[C] ""
                }
            ],
            ""prefix"": ""[C] ""
        },
        {
            ""name"": ""Test 2"",
            ""code"": ""44255352"",
            ""table"": ""SNOMEDCT"",
            ""addedby"": ""morgan.baxter"",
            ""dateadded"": 1544523489235,
            ""qualifier"": [
                {
                    ""name"": ""Qualifier"",
                    ""value"": ""Confirmed Diagnosis"",
                    ""code"": ""53252355"",
                    ""prefix"": ""[C] ""
                }
            ],
            ""prefix"": ""[C] ""
        }
    ]
    ";
                System.Web.Script.Serialization.JavaScriptSerializer js = new System.Web.Script.Serialization.JavaScriptSerializer();
    
                // Deserialize the string
                var diagnoses = js.Deserialize<Diagnosis[]>(json);
    
                Console.WriteLine("Complete");
                Console.ReadKey();
    
    
            }
        }
    }
