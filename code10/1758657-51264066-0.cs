        public class BaseDtoJsonConvertor : JsonConverter
        {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var actionRequestDto = (ActionRequestDto)value;
            writer.WriteStartObject();
            writer.WritePropertyName("ActionRequestDto");
            serializer.Serialize(writer, actionRequestDto.ToString());
            writer.WriteEndObject();
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            // Variables to be set along with sensing variables
            ActionRequestDto actionRequestDto = new ActionRequestDto();
            // Read the properties
            while (reader.Read())
            {
                if (reader.TokenType != JsonToken.PropertyName)
                {
                    break;
                }
                var propertyName = (string)reader.Value;
                if (!reader.Read())
                {
                    continue;
                }
                // Set the group
                if (propertyName.Equals("object", StringComparison.OrdinalIgnoreCase))
                {
                    actionRequestDto.Object = JsonSerializerBaseObjectFactory.DeserializeObject(actionRequestDto.ObjectType, reader, serializer);
                }
                if (propertyName.Equals("ActionType", StringComparison.OrdinalIgnoreCase))
                {
                    actionRequestDto.ActionType = serializer.Deserialize<string>(reader);
                }
                if (propertyName.Equals("ObjectType", StringComparison.OrdinalIgnoreCase))
                {
                    actionRequestDto.ObjectType = serializer.Deserialize<string>(reader);
                }
                if (propertyName.Equals("Transmited", StringComparison.OrdinalIgnoreCase))
                {
                    actionRequestDto.Transmited = serializer.Deserialize<bool>(reader);
                }
                if (propertyName.Equals("CreationDate", StringComparison.OrdinalIgnoreCase))
                {
                    actionRequestDto.CreationDate = serializer.Deserialize<DateTime>(reader);
                }
                if (propertyName.Equals("RequestNumber", StringComparison.OrdinalIgnoreCase))
                {
                    actionRequestDto.RequestNumber = serializer.Deserialize<int>(reader);
                }
                if (propertyName.Equals("Reference", StringComparison.OrdinalIgnoreCase))
                {
                    actionRequestDto.Reference = serializer.Deserialize<string>(reader);
                }
            }
            return actionRequestDto;
        }
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(ActionRequestDto);
        }
        }
