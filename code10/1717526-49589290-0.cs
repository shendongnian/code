    private string RealPartString()
    {
        if (real == 0) { return imaginary == 0 ? "0" : null; }
    
        return real.ToString();
    }
    
    private string ImaginaryPartString()
    {
        if (imaginary == 0) { return null; }
    
        if (Math.Abs(imaginary) == 1) { return imaginary == 1 ? "i" : "-i"; }
    
        return imaginary.ToString() + "i";
    }
    
    public override string ToString()
    {
        var parts = new[] { RealPartString(), ImaginaryPartString() }.Where(s => s != null);
        return string.Join(" + ", parts);
    }
