    public static double roundValue(double rawValue, double valueTick)
    {
        if (valueTick <= 0.0) return 0.0;
    
        Decimal val = new Decimal(rawValue);
        Decimal step = new Decimal(valueTick);
        Decimal modulo = Decimal.Round(Decimal.Divide(val,step));
    
        return Decimal.ToDouble(Decimal.Multiply(modulo, step));
    }
