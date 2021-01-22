    public static StringBuilder AppendFixed(this StringBuilder sb, int length, string value)
    {
        if (String.IsNullOrWhiteSpace(value))
            return sb.Append(String.Empty.PadLeft(length));
        if (value.Length <= length)
            return sb.Append(value.PadLeft(length));
        else
            return sb.Append(value.Substring(0, length));
    }
    public static StringBuilder AppendFixed(this StringBuilder sb, int length, string value, out string rest)
    {
        rest = String.Empty;
        if (String.IsNullOrWhiteSpace(value))
            return sb.AppendFixed(length, value);
        if (value.Length > length)
            rest = value.Substring(length);
        return sb.AppendFixed(length, value);
    }
