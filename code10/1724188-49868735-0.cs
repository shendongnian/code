    using System;
    using System.Text.RegularExpressions;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using Newtonsoft.Json.Serialization;
    using System.Dynamic;
    public class Program
    {
        public class C
        {
            public JRaw Prop { get; set; }
        }
        public static void Main()
        {
            var a = new JRaw("{\"A\":42}");
            var c = new C { Prop = a };
            var camelCaseSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            var result = JsonConvert.SerializeObject(c, camelCaseSettings);
            var interimObject = JsonConvert.DeserializeObject<ExpandoObject>(result);
            result = JsonConvert.SerializeObject(interimObject, camelCaseSettings);
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
