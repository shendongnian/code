    static double compNumbers(double x, double y)
    {
        if (x == y)
        {
            return 0;
        }
        else if (x > y)
        {
            return 1;
        }
        else if (y > x)
        {
            return -1;
        }
        return double.NaN
    }
