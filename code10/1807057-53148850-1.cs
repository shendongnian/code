    public static double ComputeAreaModernIs(object shape)
    {
        if (shape is Square s)
            return s.Side * s.Side;
        else if (shape is Circle c)
            return c.Radius * c.Radius * Math.PI;
        else if (shape is Rectangle r)
            return r.Height * r.Length;
        // elided
        throw new ArgumentException(
            message: "shape is not a recognized shape",
            paramName: nameof(shape));
    }
