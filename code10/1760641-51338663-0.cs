    public static void Main()
    {
        Console.Write("Please enter a number: ");
        int number = int.Parse(Console.ReadLine());
        // TO-DO: validate number here....
        for (int i = 1; i <= number; i++)
        {
            bool isMultipleOf7 = i % 7 == 0;
            Console.WriteLine(isMultipleOf7 ? "BOOM" : i.ToString());
        }
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
