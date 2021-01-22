    public static double Round(double val)
    {
        int baseNum = val <= 100 ? 100 : 1000;
        double factor = 0.5;
        double v = val / baseNum;
        var res = Math.Ceiling(v / factor) / (1 / factor) * baseNum;
        return res;
    }
