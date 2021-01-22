    public static bool TryConvert<T, U>(T t, out U u)
    {
        try
        {
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(U));
            if (!converter.CanConvertFrom(typeof(T)))
            {
                u = default(U);
                return false;
            }
            u = (U)converter.ConvertFrom(t);
            return true;
        }
        catch (Exception e)
        {
            if (e.InnerException is FormatException)
            {
                u = default(U);
                return false;
            }
            throw;
        }
    }
