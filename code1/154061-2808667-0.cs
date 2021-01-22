    Regex blabla = new Regex(@"([^0-9]*(?<number>[0-9])+)*");
    MatchCollection matches = blabla.matches("OPTIDX 26FEB2009 NIFTY CE 2500");
    foreach(Match m in matches)
    {
    string number = m.Groups["number"].Value;
    //do something with the match...
    }
