    if (pval != null)
    {
        // this is bad, an IndexOutOfRangeException will be thrown
        // if pval contains less than 2 elements:
        // Console.WriteLine(pval[0] + "," + pval[1]);
        // use string.Join instead::
        Console.WriteLine(string.Join(",", pval));
    }
