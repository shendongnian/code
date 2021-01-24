    var res = new List<int>();
    var regex = new Regex(@"\d+");
    void addMatches(string text) {
        foreach (Match match in regex.Matches(text))
        {
            int number = int.Parse(match.Value);
            res.Add(number);
        }
    }
    string test = "number1+3";
    addMatches(test);
    string test1 = "number 1+4";
    addMatches(test1);
