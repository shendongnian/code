    static void Main(string[] args)
    {
        Console.WriteLine("Enter Text");
    	var userEntry = Console.ReadLine();
    	var countOfWords = userEntry.Split(new []{" "},StringSplitOptions.RemoveEmptyEntries).Count();
    	var sum = userEntry.Where(c => Char.IsDigit(c)).Select(x=>int.Parse(x.ToString())).Sum();
    	Console.WriteLine($"Count Of Words :{countOfWords}{Environment.NewLine}Sum :{sum}");
    }
