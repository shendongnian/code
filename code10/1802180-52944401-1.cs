    static void Main(string[] args)
    {
        Console.WriteLine("This program will convert numbers that you enter into their spoken English counterpart.\nExample: 100 = One Hundred.\n\nPlease enter your desired number to convert: ");
        // Static method call
        string ConvertedValue=ToText.ConvertToText(Console.ReadLine());
        Console.WriteLine(ConvertedValue);
    }
