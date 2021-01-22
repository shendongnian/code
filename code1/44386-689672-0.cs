    public static string ProperSpace(string text)
    {
        return text.Aggregate(new StringBuilder(), (sb, c) =>
            {
                if (Char.IsUpper(c))
                    sb.Append(" ");
    
                sb.Append(c);
                return sb;
            }).ToString();
    }
