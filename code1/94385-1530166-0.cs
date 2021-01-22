    public static bool IsEqualTo(this double a, double b, double margin)
    {
        return Math.Abs(a - b) < margin;
    }
    
    public static bool IsEqualTo(this double a, double b)
    {
        return Math.Abs(a - b) < double.Epsilon;
    }
