    int[] vals = new int[] { 1, 2, 3, 4, 5 };
    int sum = MvcTools.Aggregate.Functions.Sum<int>(vals);
    
    string[] strs = new string[] { "1", "2", "3", "4", "5" };
    string str = MvcTools.Aggregate.Functions.Sum<string>(strs);
