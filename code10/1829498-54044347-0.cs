    DateTime firstDate;
    bool dateConverted= false;
    
    do{
       var dateString = Console.ReadLine();
       dateConverted= DateTime.TryParseExact(dateString , "dd-MM-YYYY", System.Globalization.CultureInfo.InvariantCulture, out firstDate);
    
       if(!dateConverted)
         Console.WriteLine("Invalid date");
    }
    while(!dateConverted)
    
    
