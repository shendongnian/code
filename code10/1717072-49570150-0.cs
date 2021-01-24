    static void Main(string[] args)
    {
        List<string> textFile = new List<string>() { "set aaadb=test", "set aaadbo=dummyvalue1", "set aaacdo=dummyvalue2" };
    
        Dictionary<string, string> keyValues = new Dictionary<string, string>();
        keyValues.Add("aaadb", "MyTesting");
        keyValues.Add("aaadbo", "MyTesting1");
        keyValues.Add("aaacdo", "MyTesting3");
    
        List<string> result = new List<string>();
    
    
        foreach (var set in textFile)
        {
    		var splits = set.Split('=');
    		splits[1] = keyValues.Where(k => k.Key == splits[0].Split(' ')[1]).Select(k => k.Value).FirstOrDefault();
    
    		result.Add(string.Join("=", splits));
        }
    
        Console.ReadLine();
    }
