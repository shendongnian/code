    public class Utility
    {
        public static object JsonParser<T>(string json)
        {
            try
            {
                JToken jToken = JToken.Parse(json);
    
                if (jToken is JArray)
                    return jToken.ToObject<List<T>>();
                else if (jToken is JObject)
                    return jToken.ToObject<T>();
                else
                    return "Unable to cast json to unknown type";
            }
            catch (JsonReaderException jex)
            {
                return jex.Message;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
