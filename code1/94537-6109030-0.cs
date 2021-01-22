    public static T? ToOrDefault<T>(object value)
        where T : struct, IConvertible
    {
        var x = value as T?;
        if (x.HasValue)
        {
            return x;
        }
        if (value == null || Convert.IsDBNull(value))
        {
            return null;
        }
        try
        {
            return (T)Convert.ChangeType(value, typeof(T), CultureInfo.InvariantCulture);
        }
        catch (InvalidCastException)
        {
        }
        catch (FormatException)
        {
        }
        catch (OverflowException)
        {
        }
        catch (ArgumentException)
        {
        }
        return default(T?);
    }
