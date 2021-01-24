    public class JMSDateTimeConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return true;
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            try
            {
                JToken token = JToken.Load(reader);
                if (token.Type == JTokenType.Object && GetAllChildresnCount(token) == 2)
                {
                    return token.ToObject(objectType);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
            }
        }
        private int GetAllChildresnCount(JToken token)
        {
            var container = token as JContainer;
            if (container == null)
            {
                return 0;
            }
            var count = container.Count;
            foreach (JToken subToken in container)
            {
               count += GetAllChildresnCount(subToken);
            }
            return count;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
