    public class NullableQueryStringConverter : QueryStringConverter
    {
        public override bool CanConvert(Type type)
        {
            var underlyingType = Nullable.GetUnderlyingType(type);
            return (underlyingType != null && base.CanConvert(underlyingType)) || base.CanConvert(type);
        }
        public override object ConvertStringToValue(string parameter, Type parameterType)
        {
            var underlyingType = Nullable.GetUnderlyingType(parameterType);
            // Handle nullable types
            if (underlyingType != null)
            {
                // Define a null value as being an empty or missing (null) string passed as the query parameter value
                return String.IsNullOrEmpty(parameter) ? null : base.ConvertStringToValue(parameter, underlyingType);
            }
            return base.ConvertStringToValue(parameter, parameterType);
        }
    }
