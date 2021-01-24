    static void Main(string[] args)
    {
        int input = 5;
        int sum = 0;
        for (int i = 0; i < input;)
        {
            if (!(++i).IsPrime())
                continue;
            sum += i;
        }
        Console.WriteLine(sum);
    }
