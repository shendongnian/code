    static void Main(string[] args)
        {
            double counter = 0;
            for (double i = 1; i < 1000000; i++)
            {
                counter = counter + (1 / (Math.Pow(i, 2)));
            }
            counter = counter * 6;
            counter = Math.Sqrt(counter);
            Console.WriteLine(counter);
        }
