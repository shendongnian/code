    public class JsonContainer
    {
    	public object d { get; set; }
    }
    
    public T Deserialize<T>(string json)
    {
    	JsonSerializer serializer = new JsonSerializer();
    	
    	JsonContainer container = (JsonContainer)serializer.Deserialize(new StringReader(json), typeof(JsonContainer));
    	json = container.d.ToString();
    	
    	return (T)serializer.Deserialize(new StringReader(json), typeof(T));
    }
