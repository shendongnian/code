    StringBuilder builder = new StringBuilder();
    for (int i = 0; i < count; i++)
    {
        builder.Append("?,");
    }
    builder.Length--; // Remove trailing ,
    return builder.ToString();
