    public static double ComputeAreaModernSwitch(object shape)
    {
        switch (shape)
        {
            case Square s:
                return s.Side * s.Side;
            case Circle c:
                return c.Radius * c.Radius * Math.PI;
            case Rectangle r:
                return r.Height * r.Length;
            default:
                throw new ArgumentException(
                    message: "shape is not a recognized shape",
                    paramName: nameof(shape));
        }
    }
