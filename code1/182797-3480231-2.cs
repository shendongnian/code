    public void Append(this builder, string item1, string item2,
                       string item3, string item4, params string[] otherItems)
    {
        builder.Append(item1);
        builder.Append(item2);
        builder.Append(item3);
        builder.Append(item4);
        foreach (string item in otherItems)
        {
            builder.Append(item);
        }
    }
