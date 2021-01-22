    string sx = "(colorIndex=3)(font.family=Helvetica)(font.bold=1)";
    Dictionary<string,string> dic = new Dictionary<string,string>();
    Regex re = new Regex(@"\(([^=]+)=([^=]+)\)");
    foreach(Match m in re.Matches(sx))
    {
        dic.Add(m.Groups[1].Value, m.Groups[2].Value);
    }
    // extract values, to prove correctness of function
    foreach(var s in dic)
        Console.WriteLine("{0}={1}", s.Key, s.Value);
