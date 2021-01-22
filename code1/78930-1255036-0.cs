    public static T GetValueOrEmpty<T>(string text)
    {
        if (!String.IsNullOrEmpty(text))
        {
            return (T) Enum.Parse(typeof(T), text);
        }
        else
        {
            // Do something else
        }
    }
