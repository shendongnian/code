    public static void DelimitedAppend(this StringBuilder sb, string value, string delimiter)
    {
        if (sb.Length > 0)
            sb.Append(delimiter);
        sb.Append(value);
    }
