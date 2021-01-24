    private int? ConvertToDbInt(string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            return null;
        }
        return int.Parse(text);
    }
