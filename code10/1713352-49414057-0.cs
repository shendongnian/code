    var time = new DateTime(2025, 4, 15, 12, 00, 0);
    
    string currentDate = time.ToString("dd/MM/yyyy");
    string currentTime = time.ToString("HH:mm");
    int timeAdd = 4;
    
    Console.WriteLine("Press 'Enter' to advance...");
    ConsoleKeyInfo userInput = Console.ReadKey();
    
    if (userInput.Key == ConsoleKey.Enter) 
    {
        time = time.AddHours(timeAdd);
        currentTime = time.ToString("HH:mm");
    }
