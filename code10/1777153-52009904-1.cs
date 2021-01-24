        /// <summary>
    	/// The RawJsonConverter is used to convert an object's string-typed properties containing valid string-encoded
    	/// JavaScript Object Notation (JSON) into non-encoded strings so that they may be treated as JSON objects and
    	/// arrays instead of strings when their containing objects are serialized.
    	/// Note that the properties of the object must be decorated with the JsonConverterAttribute like this:
    	///		[JsonConverter(typeof(RawJsonConverter))]
    	///		public string EncodedJsonProperty { get; set; }
    	/// </summary>
    	public class RawJsonConverter : JsonConverter
    	{
    		/// <inheritdoc />
    		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    		{
    			try
    			{
    				var value = serializer.Deserialize<String>(reader).Trim();
    				return JToken.Parse(value).ToString();
    			}
    			catch (Exception ex)
    			{
    				throw new Exception("Could not parse JSON from string in RawJsonConverter.", ex);
    			}
    		}
    
    		/// <inheritdoc />
    		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    		{
    			writer.WriteRawValue((string)value);
    		}
    
    		/// <inheritdoc />
    		public override bool CanConvert(Type objectType)
    		{
    			return objectType == typeof(string);
    		}
    	}
