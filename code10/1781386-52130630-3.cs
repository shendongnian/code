    public class PSObjectJsonConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
			return typeof(PSObject).IsAssignableFrom(objectType);
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
			var psObj = (PSObject)value;
			writer.WriteStartObject();
            foreach (var prop in psObj.Properties)
            {
				//Probably we shouldn't try to serialize a property that can't be read.
				//https://docs.microsoft.com/en-us/dotnet/api/system.management.automation.pspropertyinfo.isgettable?view=powershellsdk-1.1.0#System_Management_Automation_PSPropertyInfo_IsGettable
				if (!prop.IsGettable)
					continue;			
				writer.WritePropertyName(prop.Name);
				serializer.Serialize(writer, prop.Value);
            }
			writer.WriteEndObject();
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        public override bool CanRead { get { return false; } }
    }
