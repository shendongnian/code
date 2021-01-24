    public class StringToObjectConverter<T> : Newtonsoft.Json.JsonConverter
    {
    	public override void WriteJson(JsonWriter writer, object value, 
            JsonSerializer serializer)
    	{
            //This will only be needed if you also need to serlialise
            writer.WriteRaw(JsonConvert.SerializeObject(value));
    	}
    
    	public override object ReadJson(JsonReader reader, Type objectType, 
            object existingValue, JsonSerializer serializer)
    	{
    	    return JsonConvert.DeserializeObject<T>(reader.Value.ToString());
    	}
    
    	public override bool CanRead => true;
        //We can only work with the type T, you could expand this to cope with derived types
    	public override bool CanConvert(Type objectType) => typeof(T) == objectType;
    }
