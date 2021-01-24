    static void Main(string[] args)
    {
        Console.WriteLine("Choose a number");
        int chosenNumber = Convert.ToInt32(Console.ReadLine());
        int remainder;
        string result = string.Empty;
        while (chosenNumber > 0)
        {
            remainder = chosenNumber % 16;
            chosenNumber /= 16;
            result = remainder.ToString() + result;
        }
        Console.WriteLine(result);
        Console.Read();
    }
