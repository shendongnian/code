    public bool Contains(string value)
    {
        return (this.IndexOf(value, StringComparison.Ordinal) >= 0);
    }
    public bool StartsWith(string value, bool ignoreCase, CultureInfo culture)
    {
        if (value == null)
        {
            throw new ArgumentNullException("value");
        }
        if (this == value)
        {
            return true;
        }
        CultureInfo info = (culture == null) ? CultureInfo.CurrentCulture : culture;
        return info.CompareInfo.IsPrefix(this, value,
            ignoreCase ? CompareOptions.IgnoreCase : CompareOptions.None);
    }
 
