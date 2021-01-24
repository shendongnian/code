    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Newtonsoft.Json.Schema;
    using Newtonsoft.Json.Schema.Generation;
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string json = @"{
       ""collection"":[{
          ""timePeriod"":{
             ""from"": ""2017-01-01"",
             ""to"": ""2017-02-01""
          },
          ""type"": ""a"",
          ""amount"": 463872,
          ""outstanding"": 463872,
          ""due"": ""2017-03-08""
       }]
    }";
                var generator = new JSchemaGenerator();
                JSchema schema = generator.Generate(typeof(RootObject));
                JObject data = JObject.Parse(json);
                bool isValidSchema = data.IsValid(schema);
            }
        }
    }
