    string s = @"
    OPTIDX 26FEB2009 NIFTY CE 2500
    OPTIDX NIFTY 30 Jul 2009 4600.00 PE
    OPTSTK ICICIBANK 30 Jul 2009 700.00 PA
    ";
    Regex re = new Regex(@"([+-]?\d+(?:\.\d+)?)\D*$",RegexOptions.Multiline);
    foreach (Match a in re.Matches(s)){
        System.Console.WriteLine(a.Groups[1]);
    }
    
    //2500
    //4600.00
    //700.00
