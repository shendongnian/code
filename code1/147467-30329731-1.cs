    class JsonUtil
    {
        public static string JsonPrettify(string json)
        {
            return Newtonsoft.Json.Linq.JObject.Parse(json).ToString();
        }
    }
