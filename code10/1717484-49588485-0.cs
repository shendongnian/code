    var r = new Regex(@"(?:\(Lock\))(.*?)(?:\(Unlock\))");
    MatchCollection mc = r.Matches("This is a (Lock)item response(Unlock) and (Lock)request(Unlock)");
    
    for(int i = 0; i < mc.Count; i++)
    {
        // Groups[0] always contains the whole match
        // Groups[1] contains the capturing match
        Console.WriteLine(mc[i].Groups[1].Value);
    }
