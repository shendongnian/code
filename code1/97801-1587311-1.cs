    string[] testCollection = { "1", "2", "3", "4", "5" };
    
    Action<string> primaryFunction = delegate(string s) { Console.WriteLine(s); }
    Action<string> first = delegate(string s) { Console.WriteLine("first"); }
    Action<string> odd = delegate(string s) { Console.WriteLine("odd"); }
    Action<string> after = delegate(string s) { Console.WriteLine("after"); }
    
    ForEach<string>.Loop(testCollection, primaryFunction, null, first, null, odd, null, after, ForEachExecuction.Concurrent);
