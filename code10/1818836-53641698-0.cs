    public class MySerializer : JsonConverter<TransHelper>
    {
    	public override TransHelper ReadJson(JsonReader reader, Type objectType, TransHelper existingValue, bool hasExistingValue, JsonSerializer serializer)
    	{
    		throw new NotImplementedException();
    	}
    
    	public override void WriteJson(JsonWriter writer, TransHelper value, JsonSerializer serializer)
    	{
    		if(value == null) return;
    		writer.WritePropertyName(value.Key);
    		writer.WriteValue(value.Translation);
    	}
    }
