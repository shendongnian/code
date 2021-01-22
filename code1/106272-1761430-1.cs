    public static int? TryParseInt32(string text)
    {
        int value;
        if (int.TryParse(text, out value))
        {
            return value;
        }
        else
        {
            return null;
        }
    }
