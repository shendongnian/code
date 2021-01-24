    Console.Write("Enter a date:");
    string input = Console.ReadLine(), format = "";
    
    try
    {
        if (input.Contains("-"))
        {
            format = "dd-MM-yyyy";
        }
        else if (input.Contains("/"))
        {
            format = "dd/MM/yyyy";
        }
        else if (input.Contains("."))
        {
            format = "dd.MM.yyyy";
        }
        else if (input.Contains(" "))
        {
            format = "dd MM yyyy";
        }
    
        DateTime date = DateTime.ParseExact(input, format, System.Globalization.CultureInfo.InvariantCulture);
        Console.WriteLine(date.ToShortDateString());
    }
    catch (Exception) { }
    
    Console.ReadLine();
