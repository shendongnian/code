    IEnumerable<char> query = "Not what you might expect";
    query = query.Except("aeiou");
    foreach (char Output in query)
    {
        System.Out.WriteLine(Output);
    }
