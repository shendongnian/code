    extern alias js11;
    using System;
    using js11::Newtonsoft.Json;
    
    namespace NugetRefMain {
        public class Js11Serializer : ISerializer {
            public string Serialize<T>(T obj) {
                // using JsonConverter<T>, only available in v11
                Console.WriteLine(typeof(JsonConverter<T>));
                return JsonConvert.SerializeObject(obj);
            }
        }
    }
