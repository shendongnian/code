    public static object ChangeType(object value, Type conversion)
        {
            var type = conversion;
            if (type.IsGenericType && type.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {
                if (value == null)
                {
                    return null;
                }
                type = Nullable.GetUnderlyingType(type);
            }
            return Convert.ChangeType(value, type);
        }
    public static (bool IsSuccess, object Value) TryChangeType(object value, Type conversionType)
        {
            (bool IsSuccess, object Value) response = (false, null);
            var isNotConvertible = 
                conversionType == null 
                    || value == null 
                    || !(value is IConvertible)
                || !(value.GetType() == conversionType);
            if (isNotConvertible)
            {
                return response;
            }
            try
            {
                response = (true, ChangeType(value, conversionType));
            }
            catch (Exception)
            {
                response.Value = null;
            }
            return response;
        }
    }
