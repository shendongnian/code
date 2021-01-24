    public static class JsonExtensions
    {
    	public static void RedactedWriteTo(this JToken token, JsonWriter writer)
    	{
    		if (token.Type == JTokenType.Object)
    		{
    			bool omitDataProperty = token.Value<string>("type") == "encrypted";
    
    			writer.WriteStartObject();
    			foreach (var prop in token.Children<JProperty>())
    			{
    				if (omitDataProperty && prop.Name == "data")
    					continue;
    
    				writer.WritePropertyName(prop.Name);
    				prop.Value.RedactedWriteTo(writer);  // recurse
    			}
    			writer.WriteEndObject();
    		}
    		else if (token.Type == JTokenType.Array)
    		{
    			writer.WriteStartArray();
    			foreach (var item in token.Children())
    			{
    				item.RedactedWriteTo(writer);  // recurse
    			}
    			writer.WriteEndArray();
    		}
    		else // JValue
    		{
    			token.WriteTo(writer);
    		}
    	}
    }
