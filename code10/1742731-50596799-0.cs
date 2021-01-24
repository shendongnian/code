    var path = "hello";
    var doubleQuotes = "\"\"";
    var sb = new StringBuilder(doubleQuotes)
        .Append(path)
        .Append(doubleQuotes);
    Console.WriteLine(sb.ToString()); // ""hello""
