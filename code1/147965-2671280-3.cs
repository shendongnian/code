    string stringToMatch = "thisstringrepeatsss";
    string pattern = @"(\w)\1+";
    Regex r = New Regex(pattern);
    Match m = r.Match(stringToMatch);
    While(m.Success)
    {
                       Console.WriteLine("Duplicate character " + m.ToString());
                       m = m.NextMatch();
    }
