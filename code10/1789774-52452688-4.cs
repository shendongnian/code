    Month month;    
    Day day;
    Console.WriteLine("Enter Month in Numeric form (Example 1 for January): ");
    while (!TryParse(Console.ReadLine(), out month)) 
       Console.WriteLine("OMG you had one job");
  
    Console.WriteLine($"You entered {month}");
    Console.WriteLine("Enter Day of the week in Numeric form (Example 1 for Monday): ");
    while (!TryParse(Console.ReadLine(), out day))
       Console.WriteLine("OMG you had one job");
    Console.WriteLine($"You entered {day}");
