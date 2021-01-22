    str.ThrowIfNullOrEmpty("str");
    public static void ThrowIfNullOrEmpty(this string value, string name)
    {
        if (value == null)
        {
            throw new ArgumentNullException("str");
        }
        if (value == "")
        {
            throw new ArgumentException("Argument must not be the empty string.",
                                        "str");
        }
    }
