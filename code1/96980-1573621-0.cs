    public string Format(DateTime? date, string format)
    {
        if (date == null)
            return string.Empty;
        return date.Value.ToString(format);
    }
