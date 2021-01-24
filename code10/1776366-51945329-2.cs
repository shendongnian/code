    using System;
    using Newtonsoft.Json;
    class Program
    {
        static void Main(string[] args)
        {
            string json = @"{  
       ""_id"":{  
          ""$oid"":""5b7bc6acc223c11047485dd5""
       },
       ""id"":""28679e7d-0bca-40b0-b033-044df2bb1b47"",
       ""type"":""some string""   
    }";
            var foo = JsonConvert.DeserializeObject<Foo>(json);
            Console.Read();
        }
    }
