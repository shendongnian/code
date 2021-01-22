    public static double Sum(List<double> values)
    {
        double sum = 0.0;
        foreach (double value in values)
        {
            sum += value;
        }
        return sum;
    }
