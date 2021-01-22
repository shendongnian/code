    public static string Truncate(this string value, int maxLength, bool replaceTruncatedCharWithEllipsis = false)
    {
        if (replaceTruncatedCharWithEllipsis && maxLength <= 3)
            throw new ArgumentOutOfRangeException("maxLength",
                "maxLength should be greater than three when replacing with an ellipsis.");
        
        if (String.IsNullOrWhiteSpace(value)) 
            return String.Empty;
        if (replaceTruncatedCharWithEllipsis &&
            value.Length > maxLength)
        {
            return value.Substring(0, maxLength - 3) + "...";
        }
        return value.Substring(0, Math.Min(value.Length, maxLength)); 
    }
