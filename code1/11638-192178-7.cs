    public static DateTime? TryParse(string text)
    {
        DateTime date;
        if (DateTime.TryParse(text, out date))
        {
            return date;
        }
        else
        {
            return null;
        }
    }
