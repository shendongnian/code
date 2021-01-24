	public class JsonSingleOrEmptyArrayConverter<T> : JsonConverter where T : class
	{
		//https://stackoverflow.com/questions/29449641/deserialize-json-when-type-can-be-different?rq=1
		public override bool CanConvert(Type objectType)
		{
			return typeof(T).IsAssignableFrom(objectType);
		}
		public override bool CanWrite { get { return false; } }
		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			var contract = serializer.ContractResolver.ResolveContract(objectType);
			// Allow for dictionary contracts as well as objects contracts, since both are represented by 
			// an unordered set of name/value pairs that begins with { (left brace) and ends with } (right brace).
			if (!(contract is Newtonsoft.Json.Serialization.JsonObjectContract 
				  || contract is Newtonsoft.Json.Serialization.JsonDictionaryContract))
			{
				throw new JsonSerializationException(string.Format("Unsupported objectType {0} at {1}.", objectType, reader.Path));
			}
			switch (reader.SkipComments().TokenType)
			{
				case JsonToken.StartArray:
					{
						int count = 0;
						while (reader.Read())
						{
							switch (reader.TokenType)
							{
								case JsonToken.Comment:
									break;
								case JsonToken.EndArray:
									// You might want to allocate an empty object here if existingValue is null
									// If so, do
									// return existingValue ?? contract.DefaultCreator();
									return existingValue;
								default:
									{
										count++;
										if (count > 1)
											throw new JsonSerializationException(string.Format("Too many objects at path {0}.", reader.Path));
										existingValue = existingValue ?? contract.DefaultCreator();
										serializer.Populate(reader, existingValue);
									}
									break;
							}
						}
						// Should not come here.
						throw new JsonSerializationException(string.Format("Unclosed array at path {0}.", reader.Path));
					}
				case JsonToken.Null:
					return null;
				case JsonToken.StartObject:
					existingValue = existingValue ?? contract.DefaultCreator();
					serializer.Populate(reader, existingValue);
					return existingValue;
				default:
					throw new InvalidOperationException("Unexpected token type " + reader.TokenType.ToString());
			}
		}
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}
	}
	public static partial class JsonExtensions
	{
		public static JsonReader SkipComments(this JsonReader reader)
		{
			while (reader.TokenType == JsonToken.Comment && reader.Read())
				;
			return reader;
		}
	}
