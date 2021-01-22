    public static List<PointD> Transform(List<double> x, List<double> y)
    {
        if (x.Count != y.Count)
            throw new ArgumentException("Lists are different lengths!");
        List<PointD> zipped = new List<PointD>(x.Count);
        for (int i = 0; i < x.Count; i++)
        {
             zipped.Add(new PointD { X = x[i], Y = y[i] });
        }
        return zipped;
    }
