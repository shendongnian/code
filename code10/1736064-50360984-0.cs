    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;
    namespace StackOverflow
    {
    public class Program
    {
        public static void Main(string[] args)
        {
            JArray array = new JArray();
            // Module 1
            JObject parameter = new JObject();
            AddParameter(parameter, "name", true, new[] { "option1", "option2" });
            AddParameter(parameter, "admin", true, new[] { "option1", "option2" });
            AddParameter(parameter, "path", false, new[] { "option1", "option2", "option3" });
            JObject module = new JObject();
            module.Add("testmodule1", parameter);
            array.Add(module);
            // Module 2
            parameter = new JObject();
            AddParameter(parameter, "name", true, new[] { "option1", "option2" });
            AddParameter(parameter, "server", false, Array.Empty<string>());
            AddParameter(parameter, "port", true, new[] { "option1", "option2", "option3" });
            module = new JObject();
            module.Add("testmodule2", parameter);
            array.Add(module);
			
			// Display result
            var json = array.ToString();
            Console.WriteLine(json);        
        }
        static void AddParameter(JObject jObject, string name, bool required, string[] options)
        {
            JObject parameterProperties = new JObject();
            parameterProperties.Add("required", JToken.FromObject(required));
            parameterProperties.Add("options", JToken.FromObject(options));
            jObject.Add(name, parameterProperties);
        }
    }
    }
