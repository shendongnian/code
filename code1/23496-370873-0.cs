    static bool IsNaN(this double value)
    {
        return double.IsNaN(value);
    }
    static void Main()
    {
        double x = 123.4;
        bool isNan = x.IsNaN();
    }
