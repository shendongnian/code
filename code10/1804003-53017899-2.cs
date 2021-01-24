    private static Random _rand = new Random();
    const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
    
    ...
    public static string RandomString(int length)
    {
       var result = Enumerable.Range(0, length)
                              .Select(s => chars[_rand.Next(length)])
                              .ToArray();
       return new string(result);
    }
