    public static T ToEnum<T>(this string original)
    {
        Array values = Enum.GetValues(typeof(T));
        foreach (T value in values)
        {
            if (value.ToString().ToUpperInvariant() == original.ToUpperInvariant())
                return value;
        }
        throw new NotFoundException();
    }
