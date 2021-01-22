    public static string Format(IFormatProvider provider, string format, params object[] args)
    {
        if ((format == null) || (args == null))
        {
            throw new ArgumentNullException((format == null) ? "format" : "args");
        }
        StringBuilder builder = new StringBuilder(format.Length + (args.Length * 8));
        builder.AppendFormat(provider, format, args);
        return builder.ToString();
    }
