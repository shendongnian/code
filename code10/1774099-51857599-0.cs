	public class UnderscoreCaseStringSerializer : StringSerializer
	{
		public override void Serialize(BsonSerializationContext context, BsonSerializationArgs args, string value)
		{
			value = string.Concat(value.Select((x, i) => i > 0 && char.IsUpper(x) ? "_" + x.ToString() : x.ToString())).ToLower();
			base.Serialize(context, args, value);
		}
	}
	
