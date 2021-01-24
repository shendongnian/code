    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    
    namespace Dict2JsonSO
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                Dictionary<DateTime, int> dict = new Dictionary<DateTime, int>();
                dict.Add(DateTime.Now, 100);
                dict.Add(DateTime.Now.AddSeconds(10), 10);
    
                //save
                string json = JsonConvert.SerializeObject(dict);
                System.IO.File.WriteAllText(@"D:\path.txt", json);
                
                //load
                string loadedJson = System.IO.File.ReadAllText(@"D:\path.txt");
                Dictionary<DateTime, int> loaded = JsonConvert.DeserializeObject<Dictionary<DateTime, int>>(loadedJson);
            }
        }
    }
