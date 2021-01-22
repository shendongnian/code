    DateTime dateValue = new DateTime(2008, 6, 11);
    Console.WriteLine(dateValue.ToString("ddd"));    // Displays Wed
    
    DateTime dateValue = new DateTime(2008, 6, 11);
    Console.WriteLine(dateValue.ToString("ddd", 
                      new CultureInfo("fr-FR")));    // Displays mer.
