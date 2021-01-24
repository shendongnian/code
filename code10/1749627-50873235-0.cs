    else
    {
        lines.Insert(index + 1, "");
    }
    // here the empty string becomes an empty line
    Console.WriteLine(string.Join(Environment.NewLine, lines.ToArray()));
