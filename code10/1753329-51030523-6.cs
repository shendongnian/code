	public class CustomerJsonConverter : JsonConverter
	{
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			if (value is Customer customer)
			{
				var token = new JObject
				{
					["id"] = customer.Id,
					["userName"] = customer.UserName,
					["address"] = customer.Address.Address,
					["address2"] = customer.Address.Address2,
					["city"] = customer.Address.City,
					["state"] = customer.Address.State,
					["zip"] = customer.Address.ZIP
				};
				token.WriteTo(writer);
			}
			else
			{
				throw new InvalidOperationException();
			}
				
		}
	
		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			var obj = JToken.ReadFrom(reader);
			if (obj.Type != JTokenType.Object)
			{
				return null;
			}
			return new Customer
			{
				Id = (long) obj["id"],
				UserName = (string) obj["userName"],
				Address = obj.ToObject<AddressModel>()
			};
		}
	
		public override bool CanRead => true;
	
		public override bool CanConvert(Type objectType)
		{
			return objectType == typeof(Customer);
		}
	}
