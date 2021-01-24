    List<string> listOfNationalities = // ...
    string joinedNationalities = string.Join("|", listOfNationalities);
    string pattern = $@"\b(?:{joinedNationalities})\b";
    MatchCollection matches = Regex.Matches(inputString, pattern);
    foreach (Match m in matches)
        Console.WriteLine(m.Value);
