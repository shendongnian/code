    int[] vals = new int[] { 1, 2, 3, 4, 5 };
    int sum = MvcTools.Aggregate.Functions.Sum<int>(vals);
    
    double[] dvals = new double[] { 1, 2, 3, 4, 5 };
    double dsum = MvcTools.Aggregate.Functions.Sum<double>(dvals);
    
    string[] strs = new string[] { "1", "2", "3", "4", "5" };
    string str = MvcTools.Aggregate.Functions.Sum<string>(strs);
