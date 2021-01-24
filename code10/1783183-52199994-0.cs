    char[] allowedChars = new char[] { 'a', 'b'};
    char inputChar = 'z';
            
    while(!allowedChars.Contains(inputChar)){
        Console.WriteLine("Enter a, b, c or d:");
        Console.WriteLine("Try again");
        char.TryParse(Console.ReadLine(), out inputChar);
    }
    Console.WriteLine("Success");
    Console.ReadLine();
