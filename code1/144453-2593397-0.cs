    public override string ToString()
    {
        StringBuilder builder = new StringBuilder();
        foreach (int value in table)
        {
            builder.Append(value);
            builder.Append(" ");
        }
        builder.Length--; // Remove trailing space
        return builder.ToString();
    }
