    int number = 0;
    while (number != 25)
    {
        Console.WriteLine("Guess a number between 20 through 25");
        number = int.Parse(Console.ReadLine());
        if (number != 25)
            Console.WriteLine("Keep guessing");
        else
            Console.WriteLine("Merry Christmas");
    }
    
