    public static void Main()
    {
        Console.Write("Please enter a number: ");
        int number = int.Parse(Console.ReadLine());
        // validate number here....
        for (int i = 1; i <= number; i++)
        {
            string value = IsMultipleOrContains7(i) ? "BOOM" : i.ToString();
            Console.WriteLine(value);
        }
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
    public static bool IsMultipleOrContains7(int number)
    {
        if (number % 7 == 0)
        {
            return true;
        }
        return number.ToString().Contains("7");
    }
