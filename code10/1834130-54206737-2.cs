    public class CustomStringToEnumConverter : StringEnumConverter
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (string.IsNullOrEmpty(reader.Value?.ToString()))
            {
                return null;
            }
            object parsedEnumValue;
            var isValidEnumValue = Enum.TryParse(objectType.GenericTypeArguments[0], reader.Value.ToString(), true, out parsedEnumValue);
            if (isValidEnumValue)
            {
                return parsedEnumValue;
            }
            else
            {
                return null;
            }
        }
    }
