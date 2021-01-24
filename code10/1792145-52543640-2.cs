    public static decimal Round(decimal value)
    {
        var ceiling = Math.Ceiling(value * 400);
        
        return ceiling / 400;
    }
