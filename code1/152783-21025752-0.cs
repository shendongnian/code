    public static string Truncate1(this string value, int maxLength, bool replaceTruncatedCharWithEllipsis = false)
    {
        if (replaceTruncatedCharWithEllipsis &&
            maxLength <= 3)
        { 
            throw new ArgumentOutOfRangeException("maxLength",
                "maxLength greater than three when replaceTruncatedCharWithEllipsis is true");
        }
        if (String.IsNullOrEmpty(value)) { return value; }
        if (replaceTruncatedCharWithEllipsis &&
            value.Length > maxLength)
        {
            return value.Substring(0, maxLength - 3) + "...";
        }
        return value.Substring(0, Math.Min(value.Length, maxLength)); 
    }
