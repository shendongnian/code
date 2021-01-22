    string input;
    DateTime db;
    Console.WriteLine("Enter Date in this Format(YYYY-MM-DD): ");
    input = Console.ReadLine();
    db = Convert.ToDateTime(input);
    
    //////// this methods convert string value to datetime
    ///////// in order to print date
    
    Console.WriteLine("{0}-{1}-{2}",db.Year,db.Month,db.Day);
