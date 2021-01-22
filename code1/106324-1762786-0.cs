    public static T ThrowIfNull(this T value)
    {
        if (value == null)
        {
            throw new Exception(); // Use a better exception of course
        }
        return value;
    }
