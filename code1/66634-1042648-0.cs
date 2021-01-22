    Regex regex = new Regex("(?<A>\\w+):(?<B>\\w+)=(?<C>\\w*);");
    string test = "A:B=C;D:E=F;G:E=H";
    // get all matches
    MatchCollection mc = regex.Matches(test);
    foreach (Match m in mc) { 
        Console.WriteLine("A = {0}", m.Groups["A"].Value);
        Console.WriteLine("B = {0}", m.Groups["B"].Value);
        Console.WriteLine("C = {0}", m.Groups["C"].Value);
    }
