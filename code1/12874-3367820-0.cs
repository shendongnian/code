    public T IsNull<T>(this object value, T nullAlterative)
    {
        if(value != DBNull.Value)
        {
            Type type = typeof(T);
            if (type.IsGenericType && 
                type.GetGenericTypeDefinition() == typeof(Nullable<>).GetGenericTypeDefinition())
            {
                type = Nullable.GetUnderlyingType(type);
            }
    
            return (T)(type.IsEnum ? Enum.ToObject(type, Convert.ToInt32(value)) :
                Convert.ChangeType(value, type));
        }
        else 
            return nullAlternative;
    }
