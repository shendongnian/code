    str.ThrowIfNullOrEmpty("str");
    public static void ThrowIfNullOrEmpty(this string value, string name)
    {
        if (value == null)
        {
            throw new ArgumentNullException(name);
        }
        if (value == "")
        {
            throw new ArgumentException("Argument must not be the empty string.",
                                        name);
        }
    }
