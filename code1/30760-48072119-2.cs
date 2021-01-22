    using System;
    using System.IO;
    using System.Collections.Generic;
    using Authlete.Util;
    
    namespace MyApp
    {
        class Program
        {
            public static void Main(string[] args)
            {
                string file = "test.properties";
                IDictionary<string, string> properties;
    
                using (TextReader reader = new StreamReader(file))
                {
                    properties = PropertiesLoader.Load(reader);
                }
            
                foreach (var entry in properties)
                {
                    Console.WriteLine($"{entry.Key} = {entry.Value}");
                }
            }
        }
    }
