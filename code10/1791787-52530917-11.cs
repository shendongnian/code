    public class Utility
    {
        public static List<T> JsonParser<T>(string json)
        {
            JToken jToken = JToken.Parse(json);
    
            if (jToken is JArray)
            {
                return jToken.ToObject<List<T>>();
            }
            else if (jToken is JObject)
            {
                List<T> lst = new List<T>();
                lst.Add(jToken.ToObject<T>());
                return lst;
            }
            else
                return new List<T>();
        }
    }
