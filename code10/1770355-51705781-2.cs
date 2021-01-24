		public class Vector2Converter : JsonConverter
		{
			class Vector2DTO
			{
				public float X;
				public float Y;
			}
			
			public override bool CanConvert(Type objectType)
			{
				return objectType == typeof(Vector2) || objectType == typeof(Vector2?);
			}
	
			public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
			{
				// A JSON object is an unordered set of name/value pairs so the converter should handle
				// the X and Y properties in any order.
				var dto = serializer.Deserialize<Vector2DTO>(reader);
				if (dto == null)
					return null;
				return new Vector2(dto.X, dto.Y);
			}
	
			public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
			{
				var vec = (Vector2)value;
				serializer.Serialize(writer, new Vector2DTO { X = vec.X, Y = vec.Y });
			}
		}
    Working sample fiddle [here](https://dotnetfiddle.net/kDHzkd).
    The converter serializes the `Vector2` as an object with `X` and `Y` properties, but you could also serialize it as an array with two values if you prefer.  I would not recommend serializing as a primitive `string` since `Vector2` is not, in fact, a primitive.
