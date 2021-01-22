    DateTime date1; 
    date1 = new DateTime(2008, 1, 1, 18, 9, 1);
    Console.WriteLine(date1.ToString("hh:mm:ss tt", 
                      CultureInfo.InvariantCulture));
    // Displays 06:09:01 PM  
    
    Console.WriteLine(date1.ToString("HH:mm:ss", 
                      CultureInfo.InvariantCulture));
    // Displays 18:09:01       
                 
