    public static object GetValueOrEmpty(string text, Type type)
    {
        if (!String.IsNullOrEmpty(text))
        {
            return Enum.Parse(type, text);
        }
        else
        {
            // Do something else
        }
    }
