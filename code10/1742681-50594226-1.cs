    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System.IO;
    
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string json = File.ReadAllText("TextFile1.txt");
                JObject jsonObject= (JsonConvert.DeserializeObject(json) as JObject);
                string name = jsonObject.Value<JObject>("1").Value<string>("name");
            }
        }
    }
