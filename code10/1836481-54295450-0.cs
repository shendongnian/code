    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    
    namespace ConsoleApp2
    {
        class Program
        {
            const string json = @"{
                                      ""0"": {
                                        ""id"": ""1"",
                                        ""email"": ""someemail@test.com"",
                                        ""tstamp"": ""2019-01-21 11:19:48"",
                                        ""times"": ""2"",
                                        ""tstamp_iso"": ""2019-01-21T12:19:48-05:00""
                                      },
                                      ""1"": {
                                        ""id"": ""2"",
                                        ""email"": ""someotheremail@test.com"",
                                        ""tstamp"": ""2019-01-21 11:25:48"",
                                        ""times"": ""2"",
                                        ""tstamp_iso"": ""2019-01-21T12:25:48-05:00""
                                      },
                                      ""result_code"": 1,
                                      ""result_message"": ""Success!"",
                                      ""result_output"": ""json""
                                  }";
    
            static void Main(string[] args)
            {
                JObject o = JObject.Parse(json);
    
                List<FirstObject> l = new List<FirstObject>();
    
                int c = 0;
    
                while (o[$"{c}"] != null)
                {
                    FirstObject fo = o[$"{c++}"].ToObject<FirstObject>();
                    l.Add(fo);
                }
    
                SecondObject so = JsonConvert.DeserializeObject<SecondObject>(json);
    
                so.FirstObjects = l.ToArray();
    
                Console.ReadKey();
            }
        }
    }
