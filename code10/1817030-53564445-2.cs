    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace DeserializeJson
    {
        /**
         * REFERENCE:
         * https://stackoverflow.com/questions/53562566/
         *
         * ORIGINAL ERROR:
         * "Unexpected character encountered while parsing value: {. Path '[0].Statistics', line 5, position 19."
         */
         public class Stats
         {
             public string Label { get; set; }
             public int Value { get; set; }
         }
    
         public class MyModel
         {
             public int Id { get; set; }
             public int Grade { get; set; }
             public string Statistics { get; set; }
         }
    
        class Program
        {
            static Collection<MyModel> LoadData(string data)
            {
                var retval = JsonConvert.DeserializeObject<Collection<MyModel>>(data);
                return retval;
            }
    
            static void Main(string[] args)
            {
                try
                {
                    string s = File.ReadAllText(@"test-data.json");
                    JsonConvert.DefaultSettings = () => new JsonSerializerSettings
                    {
                        Formatting = Newtonsoft.Json.Formatting.Indented
                    };
                    Collection <MyModel> mockData = Program.LoadData(s);
                    System.Console.WriteLine("#/items= " + mockData.Count);
                    foreach (MyModel item in mockData)
                    {
                        System.Console.WriteLine("  id= {0}, Grade={1}, Statistics={2}", item.Id, item.Grade, item.Statistics.ToString());
                    }
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine("ERROR:", ex);
                }
            }
        }
    }
