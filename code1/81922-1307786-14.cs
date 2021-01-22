    public static bool operator ==(Complex term1, double term2)
    {
        return term1.Equals(term2);
    }
    public static bool operator ==(double term1, Complex term2)
    {
        return term2.Equals(term1);
    }
    public static bool operator !=(Complex term1, double term2)
    {
        return !term1.Equals(term2);
    }
    public static bool operator !=(double term1, Complex term2)
    {
        return !term2.Equals(term1);
    }
