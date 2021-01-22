    public static double Mean(this IEnumerable<long> source)
    {
        if (source == null)
        {
            throw Error.ArgumentNull("source");
        }
        
        int count = source.Count();
        double mean = 0D;
    
        foreach(long x in source)
        {
            mean += (double)x/(double)count;
        }
    
        return mean;
    }
