    public static int? TryParse(string s)
    {
        int i;
        return int.TryParse(s, out i) ? (int?)i : null;
    }
    // in your method
    IEnumerable<string> input = new string[] {"a", "1","2", "b", "10"};
    var list = input.Select(s => new { IntVal = TryParse(s), String =s}).ToList();
    list.Sort((s1, s2) => {
        if(s1.IntVal == null && s2.IntVal == null)
        {
            return s1.String.CompareTo(s2.String);
        }
        if(s1.IntVal == null)
        {
            return 1;
        }
        if(s2.IntVal == null)
        {
            return -1;
        }
        return s1.IntVal.Value.CompareTo(s2.IntVal.Value);
    });
    input = list.Select(s => s.String);
        
    foreach(var x in input)
    {
        Console.WriteLine(x);
    }
