    string bar = "test, othertest";
    Regex reg = new Regex(@"[\w]+");
    
    MatchCollection b = reg.Matches(bar);
    
    string b1 = b[0].Value;
    string b2 = b[1].Value;
    
    int numberGroups = b.Count;
