    var pattern = "^[xXyYzZ]{3}$";  // note new pattern
    var input = Console.ReadLine();
    while (!Regex.IsMatch(input.Trim(), pattern);)
    {
        Console.WriteLine("YOU LOST");
        Console.WriteLine("Do it again");
        input = Console.Readline();        
    }
    Console.WriteLine("YOU WON");
