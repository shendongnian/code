    private string RealPartString()
    {
        if (real == 0) { return imaginary == 0 ? "0" : null; }
    
        return real.ToString();
    }
    
    private string ImaginaryPartString()
    {
        if (imaginary == 0) { return null; }
    
        var abs = Math.Abs(imaginary);
        var number = abs == 1 ? "" : abs.ToString();
        // Only include the sign here if there is no real part
        var sign = real == 0 && imaginary < 0 ? "-" : "";
    
        return sign + number + "i";
    }
    
    public override string ToString()
    {
        var parts = new[] { RealPartString(), ImaginaryPartString() }.Where(s => s != null);
        var sign = imaginary < 0 ? " - " : " + ";
    
        return string.Join(sign, parts);
    }
