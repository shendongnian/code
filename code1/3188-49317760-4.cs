    public static decimal NilakanthaGetPI(int n)
    {
        decimal sum = 0;
        decimal temp = 0;
        decimal a = 2, b = 3, c = 4;
        for (int i = 0; i < n; i++)
        {
            temp = 4 / (a * b * c);
            sum += i % 2 == 0 ? temp : -temp;
            a += 2; b += 2; c += 2;
        }
        return 3 + sum;
    }
