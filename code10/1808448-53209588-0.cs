    var builder=new StringBuilder();
    foreach(var page in list)
    {
        builder.AppendLine(string.Join(",", page));
    }
    string toDisplay = builder.ToString();
