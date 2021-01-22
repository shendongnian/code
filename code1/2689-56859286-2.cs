    public static T ToEnum<T>(dynamic value)
    {
        if (value == null)
        {
            // default value of an enum is the object that corresponds to
            // the default value of its underlying type
            // https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/default-values-table
            value = Activator.CreateInstance(Enum.GetUnderlyingType(typeof(T)));
        }
        else if (value is string name)
        {
            return (T)Enum.Parse(typeof(T), name);
        }
        return (T)Enum.ToObject(typeof(T),
                 Convert.ChangeType(value, Enum.GetUnderlyingType(typeof(T))));
    }
