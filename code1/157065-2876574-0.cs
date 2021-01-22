    string Normalize(string value)
    {
        if (String.IsNullOrEmpty(value)) return value;
        StringBuilder builder = new StringBuilder(value.Length + value.Length/3);
        for (int ii = 0; ii < value.Length; ++ii)
        {
            if (Char.IsLetterOrDigit(value[ii]))
            {
                builder.Append(value[ii]);
                if ((builder.Length % 3) == 0) builder.Append('-');
            }
        }
        return builder.ToString().TrimEnd('-');
    }
