    string test = @"""0"",""Column"",""column2"",""Column3""";
    Regex regex = new Regex(@"(?<=[""])[^,]*?(?=[""])");
    foreach (Match match in regex.Matches(test))
    {
        Console.WriteLine(match.Value);
    }
