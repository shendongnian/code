    private static object Tranc(List<Expression.Expression> p)
    {
        var target = (decimal)p[0].Evaluate();
    
    	// check if formula contains only one argument
        var digits = p.Count > 1
            ? (decimal) p[1].Evaluate()
            : 0;
    
        return Math.Truncate((double)target * Math.Pow(10, (int)digits)) / Math.Pow(10, (int)digits);
    }
