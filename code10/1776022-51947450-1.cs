    public class DefCollectionJConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            JArray array = new JArray();
            IList list = (IList)value;
    
            if (list.Count > 0)
            {
                // Populate the JArray with JTokens from the list elements. Pass the current serializer, which should contain default settings and converters.
                // This should handle child objects appropriately, too.
                JsonSerializer defSerializer = new JsonSerializer();
                defSerializer.Converters.Add(new DefinitionJConverter());
    
                for (int e = 0; e < list.Count; e++)
                {
                    JToken first = JToken.FromObject(list[e], serializer);
                    array.Add(first);
                }
    
                array.WriteTo(writer);
            }
            else
            {
                Debug.LogError("List was empty.");
            }
        }
    }
    public class RefCollectionJConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            JArray array = new JArray();
            IList list = (IList)value;
    
            if(list.Count > 0)
            {
                // Populate the JArray with JTokens of the list elements, using a serialiser that only contains ReferenceJConverter.
                // Note that we don't need to worry about this token's children: only definitions can describe children.
                JsonSerializer refSerializer = new JsonSerializer();
                refSerializer.Converters.Add(new ReferenceJConverter());
    
                for(int e = 0; e < list.Count; e++)
                {
                    JToken first = JToken.FromObject(list[e], refSerializer);
                    array.Add(first);
                }
    
                array.WriteTo(writer);
            }
            else
            {
                Debug.LogError("List was empty.");
            }
        }
    }
