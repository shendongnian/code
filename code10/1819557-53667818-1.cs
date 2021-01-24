    static SqlDecimal PowerOfTen(int power)
    {
        // Note: only works for non-negative power values at the moment!
        // (To handle negative input, divide by 10 on each iteration instead.)
        SqlDecimal result = 1;
        for (int i = 0; i < power; i++)
        {
            result = result * 10;
        }
        return result;
    }
