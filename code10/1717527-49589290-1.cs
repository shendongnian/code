    private string RealPartString()
    {
        if (real == 0) { return imaginary == 0 ? "0" : null; }
    
        return real.ToString();
    }
    
    private string ImaginaryPartString()
    {
        if (imaginary == 0) { return null; }
    
        var number = Math.Abs(imaginary) == 1 ? "" : Math.Abs(imaginary).ToString();
        var sign = real == 0 && imaginary < 0 ? "-" : "";
    
        return sign + number + "i";
    }
    
    public override string ToString()
    {
        var parts = new[] { RealPartString(), ImaginaryPartString() }.Where(s => s != null);
        var sign = imaginary < 0 ? " - " : " + ";
    
        return string.Join(sign, parts);
    }
