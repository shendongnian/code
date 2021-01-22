    // number of digits to be compared    
    public int n = 12 
    // n+1 because b/a tends to 1 with n leading digits
    public double MyEpsilon { get; } = Math.Pow(10, -(n+1)); 
    
    public bool IsEqual(double a, double b)
    {
        // Avoiding division by zero
        if (Math.Abs(a)<= double.Epsilon || Math.Abs(b) <= double.Epsilon)
            return Math.Abs(a - b) <=  double.Epsilon;
        
        // Comparison
        return Math.Abs(1.0 - a / b) <=  MyEpsilon;
    }
