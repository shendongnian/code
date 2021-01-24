    static void Main(string[] args)
    {
    	Console.WriteLine(ConsoleApp1.Strings.HelloString);
    
    	CultureInfo.CurrentUICulture = CultureInfo.CreateSpecificCulture("es");
    	Console.WriteLine(ConsoleApp1.Strings.HelloString);
    }
