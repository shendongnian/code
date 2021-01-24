    public static void Main()
    {
        Random roll = new Random();
        for (int a = 0; a < 20; a = a + 1)
        {
            Console.WriteLine(roll.Next(1, 6 + 1));
        }
        Console.ReadLine();
     }
