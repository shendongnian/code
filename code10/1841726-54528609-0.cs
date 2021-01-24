    public static Random _rnd=new Random();
    public static string WeirdShuffle(string input, int n)
    {
       return string.Join("", input.ToCharArray()
                                   .Select((s, i) => (s, i))
                                   .GroupBy(x => x.i / n)
                                   .Select(grp => new string(grp.Select(x => x.s)
                                                                .OrderBy(x => _rnd.Next())
                                                                .ToArray())));
    } 
