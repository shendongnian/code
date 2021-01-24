    string input = "InitValue(test, othertest, bleh, blehTest, foo)";
    
    Regex regArgs = new Regex(@"(?:InitValue\()(.*)(?:\))");
    Match matchArgs = regArgs.Match(input);
    
    string valueArgs = matchArgs.Groups[1].Value;
    
    Regex reg = new Regex(@"[\w]+");
    
    MatchCollection b = reg.Matches(valueArgs);
    
    string b1 = b[0].Value;
    string b2 = b[1].Value;
    
    int numberGroups = b.Count;
