    private bool IsPrime(int startNumb, int endNumb)
    {
        for (int i = startNumb; i <= endNumb; i++)
        {
            for (int j = 2; j <= i; j++)
            {
                if (i % j == 0)
                {
                    return false;
                }
            }
        }
        return true;
    }
