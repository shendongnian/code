    static void Main(string[] args)
    {
        int amount;
        int value;
        Console.WriteLine("Amount: ");
        amount = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("values: ");        
        int[] tomb = new int[amount];
        for (int i = 0; i < amount; i++)
        {
            tomb[i] = Convert.ToInt32(Console.ReadLine());
        }
        value = tomb[0]; //Get the first user input value
        Console.WriteLine(".....");
        for (int i = 0; i < amount; i++)
        {
            Console.WriteLine(tomb[i]);
        }
        Console.ReadKey();
    }
