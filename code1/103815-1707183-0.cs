    public static double SplitTime(TimeSpan input, TimeSpan splitSize)
    {
        double msInput = input.TotalMilliseconds;
        double msSplitSize = splitSize.TotalMilliseconds;    
        return  msInput / msSplitSize;
    }
