    public string Truncate(this string value, int maximumLength)
    {
        if (string.IsNullOrEmpty(value) == true) { return value; }
        if (maximumLen < 0) { return String.Empty; }
        if (value.Length > maximumLength) { return value.Substring(0, maximumLength); }
        return value;
    }
