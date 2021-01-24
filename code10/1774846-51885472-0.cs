    string json = @"{""val"": null}";
    
    public class NoAnnotation {
    	public decimal val {get; set;}
    }
    
    public class WithAnnotation {
    	[JsonConverter(typeof(CustomDecimalNullConverter))]
    	public decimal val {get; set;}
    }
    
    void Main()
    {	
    	// Converting a type that specifies the converter
        // with attributes works without additional setup
    	JsonConvert.DeserializeObject(json, typeof(WithAnnotation));
    	
    	// Converting a POCO doesn't work without some sort of setup,
    	// this would throw
    	// JsonConvert.DeserializeObject(json, typeof(NoAnnotation));
    	
    	// You can specify which extra converters
        // to use for this specific operation.
    	// Here, the converter will be used
        // for all decimal properties
    	JsonConvert.DeserializeObject(json, typeof(NoAnnotation),
           new CustomDecimalNullConverter());
    	
    	// You can also create custom serializer settings.
    	// This is a good idea if you need to serialize/deserialize multiple places in your application,
    	// now you only have one place to configure additional converters
    	var settings = new JsonSerializerSettings();
    	settings.Converters.Add(new CustomDecimalNullConverter());
    	JsonConvert.DeserializeObject(json, typeof(NoAnnotation), settings);
    }
    
    // For completeness: A stupid example converter
    class CustomDecimalNullConverter : JsonConverter
    {
    	public override bool CanConvert(Type objectType)
    	{
    		return objectType == typeof(decimal);
    	}
    
    	public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    	{
    		if (reader.TokenType == JsonToken.Null)
    		{
    			return 0m;
    		}
    		else
    		{
    			return Convert.ToDecimal(reader.Value);
    		}
    	}
    
    	public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    	{
    		writer.WriteValue((decimal)value);
    	}
    }
