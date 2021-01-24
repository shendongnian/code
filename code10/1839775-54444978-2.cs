    static readonly int[] _monthLimits = new int[] { 1, 2, 4, 6, 9, 12, 15, 18, 24, 30, 36, 48, 60 };
    
    public static int VisitMonth(int months)
    {
        int visit = 0;
    
        var maxMonths = _monthLimits[_monthLimits.Length - 1];
        if (months <= maxMonths)
        {
            // Only iterate through month limits if the given "months" is below the max available limit
            for (var i = 0; i < _monthLimits.Length; i++)
            {
                if (months <= _monthLimits[i])
                {
                    visit = i + 1;
                    break;
                }
            }
        }
        else
        {
            // The given "months" is over the max, default to the size of the array
            visit = _monthLimits.Length + 1;
        }
                
        return visit;
    }
