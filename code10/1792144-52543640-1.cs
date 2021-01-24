    public static decimal Round(decimal value)
    {
        var ceiling = Math.Ceiling(value * 400);
        if (ceiling == 0)
        {
            return 0;
        }
        return ceiling / 400;
    }
