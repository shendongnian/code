    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string json1 = @"{
                                    ""success"":true,
                                    ""Data"":[{id:1, name:""Paul""},{id:2,name:""neville""},{id:3,name:""jason""}]
                                }";
    
                string json2 = @"{
                                    ""success"":true,
                                    ""Data"":{id:1,classSize:30,minAge:25, maxAge:65}
                                 }";
    
                string j = json1; //json2;
    
                JObject jo = JObject.Parse(j);
    
                ApiResponse parsed;
    
                if (jo["Data"].Type == JTokenType.Array)
                    parsed = jo.ToObject<ApiUsersResponse>();
                else
                    parsed = jo.ToObject<ApiAgeResponse>();
    
                Console.ReadKey();
            }        
        }
    
        class User
        {
            public int id { get; set; }
            public string name { get; set; }
        }
    
        class AgeClass
        {
            public int id { get; set; }
            public int classSize { get; set; }
            public int minAge { get; set; }
            public int maxAge { get; set; }
        }
    
        class ApiResponse
        {
            public bool success { get; set; }
        }
        class ApiUsersResponse : ApiResponse
        {
            public List<User> Data { get; set; }
        }
    
        class ApiAgeResponse : ApiResponse
        {            
            public AgeClass Data { get; set; }
        }     
    }
