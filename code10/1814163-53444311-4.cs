    public class Utility
    {
        public static string JsonParser(string json)
        {
            JToken jTokenMain = JToken.Parse(json);
            JToken jToken = jTokenMain["DATA"];
            List<object> list = new List<object>();
            if (jToken is JArray)
            {
                list = jToken.ToObject<List<object>>();
            }
            else if (jToken is JObject)
            {
                list.Add(jToken.ToObject<object>());
            }
            JToken data = JToken.FromObject(list);
            jTokenMain["DATA"] = data;
            return jTokenMain.ToString();
        }
    }
