    public static decimal GregoryLeibnizGetPI(int n)
    {
        decimal sum = 0;
        decimal temp = 0;
        for (int i = 0; i < n; i++)
        {
            temp = 4m / (1 + 2 * i);
            sum += i % 2 == 0 ? temp : -temp;
        }
        return sum;
    }
