    class IfSelect
    {
    public static void Main()
    {
        string myInput;
        int myInt;
        Console.Write("Please enter a number: ");
        myInput = Console.ReadLine();
        myInt = Int32.Parse(myInput);
        if (myInt == 10)
        {
            Console.WriteLine(string.Format("Your number is {0}.  Press any key.", myInt));
            Console.ReadLine();
        }
    }
    }
