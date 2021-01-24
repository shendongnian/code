    using System;
    using global::Newtonsoft.Json;
    
    namespace NugetRefMain {
        public class Js10Serializer : ISerializer
        {
            public string Serialize<T>(T obj)
            {
                Console.WriteLine(typeof(JsonConvert));
                return JsonConvert.SerializeObject(obj);
            }
        }
    }
