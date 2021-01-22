    StringBuilder builder = new StringBuilder();
    
    if (array.Length > 0)
    {
        builder.Append(array[0]);
    }
    for (var i = 1; i < array.Length; ++i)
    {
        builder.Append(separator);
        builder.Append(array[i]);
    }
    string joined = builder.ToString(); // "a b c"
