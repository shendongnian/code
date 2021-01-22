    static void Main(string[] args)
    {
        const int precision = 10000;
        foreach (var d in new[] { 2, 2.9, 2.001, 1.999, 1.99999999, 2.00000001 })
        {
            if ((int) (d*precision + .5)%precision == 0)
            {
                Console.WriteLine("{0} is an int", d);
            }
        }
    }
