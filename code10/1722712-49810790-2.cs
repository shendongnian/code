    public static bool ContainsDigit(int input, int digit)
    {
        do
        {
            if (input % 10 == digit)
            {
                return true;
            }
            input /= 10;
        }
        while (input > 0);
        return false;
    }
