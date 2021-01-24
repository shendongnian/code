    static void Main(string[] args)
    {
    	Console.Write("How many numbers will you want to enter? ");
    	int num1 = int.Parse(Console.ReadLine());
    	Console.WriteLine("Enter " + num1 + " numbers");
    	for (; num1 > 0; num1--)
    	{
    		int currentLine = Console.CursorTop;
    		string num2 = Console.ReadLine();
    		Console.SetCursorPosition(20, currentLine);
    		Console.WriteLine(new string('-', num2.Length));
    	}
    
    	Console.WriteLine("\r\n(Press enter to leave program.)");
    	Console.ReadLine();
    }
