    public class LangEntryConverter: JsonConverter<string[]>
    {
        // WriteJson implementation only needed if you need to serialize a value back to Json
        public override void WriteJson(JsonWriter writer, string[] value, JsonSerializer serializer)
        {
    		if (value.Length == 1)
    		{
    			writer.WriteValue(value[0]);
    		}
    		else
    		{
        		writer.WriteStartArray();
    			for (var i = 0; i < value.Length; i++)
    			{
    				writer.WriteValue(value[i]);
    			}
        		writer.WriteEndArray();
    		}
        }
    
        public override string[] ReadJson(JsonReader reader, Type objectType, string[] existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
    		var values = new List<string>();
    		if (reader.TokenType == JsonToken.StartArray)
    		{
    			while (reader.Read() && reader.TokenType != JsonToken.EndArray)
    			{
    			    if (reader.TokenType == JsonToken.String)
    			    {
    			        values.Add((string)reader.Value);
    			    }
    				else
    				{
    					throw new Exception($"Unexpected token type: {reader.TokenType}");
    				}
    			}
    		}
    		else if (reader.TokenType == JsonToken.String)
    		{
            	values.Add((string)reader.Value);
    		}
    
            return values.ToArray();
        }
    }
