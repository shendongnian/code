    Regex r = new Regex(@"("".*?"")|(\S+)"); 
    MatchCollection mc = r.Matches(input);
    for (int i = 0; i < mc.Count; i++) 
    {
       Console.WriteLine(mc[i].Value);
    }
    
