    public static string ToHexString(string value)
    {
        return value.Aggregate(new StringBuilder("0x"),
            (sb, c) => sb.AppendFormat("{0:x2}", (int)c)).ToString();
    }
