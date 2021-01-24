    public class BConverter : JsonConverter
    {
        public override object ReadJson(JsonReader reader, Type type, 
            object value, JsonSerializer serializer)
        {
    		JObject jobject = JObject.Load(reader);
    		if (jobject.ContainsKey("CProperty"))
    		{
    			return jobject.ToObject<C>(serializer);
    		}
    
    		if (jobject.ContainsKey("DProperty"))
    		{
    			return jobject.ToObject<D>(serializer);
    		}
    
    		throw new Exception("Um, this is some other type!");
    	}
    
    	public override bool CanConvert(Type type) => type == typeof(B);
    	public override bool CanWrite => false;
    	public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) 
            => throw new NotImplementedException();
    }
