    1 ask 1 questions on 2Over2.com
----------
    static void Main()
    {
        string myString = "You ask your questions on StackOverFlow.com";
    
        Dictionary<int, List<string>> collections = new Dictionary<int, List<string>>()
        {
            { 1, new List<string>() { "You", "your" } },
            { 2, new List<string>() { "Stack", "Flow" } },
        };
    
        var tempColl = collections.SelectMany(c => c.Value);
        // { "You", "your", "Stack", "Flow" }
        
        string separator = String.Join("|", tempColl);
        // "You|your|Stack|Flow"
        
        var splitted = Regex.Split(myString, @"("+separator+")");
        // { "", "You", " ask ", "your", " questions on ", "Stack", "Over", "Flow", ".com" }
    
        for(int i=0;i<splitted.Length;i++)
        {
            foreach(var index in collections.Keys)
            {
                foreach(var str in collections[index])
                {
                    splitted[i] = splitted[i].Replace(str, index.ToString());
                }
            }
        }
    
        foreach(var s in splitted)
        {
            Console.WriteLine("\""+s+"\"");
        }
    }
