    static readonly int[] _monthLimits = new int[] { 1, 2, 4, 6, 9, 12, 15, 18, 24, 30, 36, 48, 60 };
    
    public static int VisitMonth(int months)
    {
        int visit = _monthLimits.Length + 1;
    
        for (var i = 0; i < _monthLimits.Length; i++)
        {
            if (months <= _monthLimits[i])
            {
                visit = i + 1;
                break;
            }
        }
    
        return visit;
    }
