    // Add NuGet 'Newtonsoft.Json' then:
    using Newtonsoft.Json;
    class Data
    {
        public string d;
        static Dictionary<String, String> DecodeDictionary(string json)
        {
            var data = JsonConvert.DeserializeObject<Data>(jsonString);
            return JsonConvert.DeserializeObject<Dictionary<String, String>>(data.d);
        }
    }
