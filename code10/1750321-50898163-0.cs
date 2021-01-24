    using System;
    using System.IO;
    using Newtonsoft.Json.Linq;
       
    class Test
    {
        static void Main()
        {
            string json = File.ReadAllText("test.json");
            string code = "ru";
            JObject dataObject = JObject.Parse(json);
            string result = (string) dataObject["langs"][code];
            Console.WriteLine(result);
        }
    }
