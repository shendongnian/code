    public double DotProduct2(MyDoubles[] values)
    {
        double res = 0;
        for (int i = 0; i < values.Length; i++)
        {
            res += values[i].Product();
        }
        return res;
    }
