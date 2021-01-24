    public bool DataHasOutliers(IEnumerable<double> results, Limits limits)
    {
        if(limits.High < limits.Low) 
        {
             throw new ArgumentOutOfRangeException();
        }
        double delta = limits.High - limits.Low;
        double upperThreshold = 0.9 * delta + limits.Low;
        double lowerThreshold = 0.1 * delta + limits.Low;
        foreach (double result in results)
        {
            //detect if any result values are in the low or high regions of the acceptable limits
            if (result >= upperThreshold)
            {
                "".Dump("Upper threshold violated");
                return true;
            }
            if (result <= lowerThreshold)
            {
                "".Dump("Lower threshold violated");
                return true;
            }
        }
        return false;
    }
