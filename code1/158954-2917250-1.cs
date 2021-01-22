    public static bool IsNumeric(object o)
    {
        const NumberStyles sty = NumberStyles.Any;
        double d;
        return (o != null && Double.TryParse(o.ToString(), sty, null, out d));
    }
