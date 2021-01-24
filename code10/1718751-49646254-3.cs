	class GuardianPatientConverter : JsonConverter
	{
		public override bool CanRead
		{
			get { return true; }
		}
		public override bool CanWrite
		{
			get { return false; }
		}
		public override bool CanConvert(Type objectType)
		{
			return typeof(GuardianPatient) == objectType;
		}
		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			if (reader.TokenType == JsonToken.Null)
			{
				return null;
			}
			var jObject = JObject.Load(reader);
			var guardian = new Guardian();
			var patient = new Patient();
			serializer.Populate(jObject.CreateReader(), guardian);
			serializer.Populate(jObject.CreateReader(), patient);
			return new GuardianPatient()
			{
				Guardian = guardian,
				Patient = patient
			};
		}
		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}
	}
