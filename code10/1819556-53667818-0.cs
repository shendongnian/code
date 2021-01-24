    static SqlDecimal PowerOfTen(int power)
    {
        // Note: only works for non-negative power values!
        SqlDecimal result = 1;
        for (int i = 0; i < power; i++)
        {
            result = result * 10;
        }
        return result;
    }
