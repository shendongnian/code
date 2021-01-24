    public static string StringOfChar(int scale)
    {
       var list = Enumerable.Range(1, scale)
                            .Select(x => (char)(_rand.Next(32)+32))
                            .ToArray();
       return string.Join("", list);
    } 
