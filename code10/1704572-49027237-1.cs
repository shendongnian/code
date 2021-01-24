    static char GetMenuOption()
    {
        Console.WriteLine("Please enter C, F, K, R, X: ");
        char letter = Convert.ToChar(Console.ReadLine());
        return letter;
    }
    static int GetValue()
    {
        Console.WriteLine("Please enter the value to convert: ");
        int value = Convert.ToInt32(Console.ReadLine());
        return value;
    }
