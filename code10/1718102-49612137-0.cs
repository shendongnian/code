    using System;
    using System.Linq;
    using Newtonsoft.Json.Linq;
    
    class Test
    {
        static void Main()
        {
            string json = @"{
      'datatype_properties': {
        'country_name_iso3166_short': [
          'Text Text'
        ]
      }
    }".Replace("'", "\"");
            JObject parent = JObject.Parse(json);
            string countryName = parent["datatype_properties"]
                .Value<JArray>("country_name_iso3166_short")
                .Values<string>()
                .FirstOrDefault();
            Console.WriteLine(countryName);
        }
    }
