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
                object myStuff = JsonConvert.DeserializeObject(json);
                string name = (myStuff as JObject).Value<JObject>("1").Value<string>("name");
            }
        }
    }
