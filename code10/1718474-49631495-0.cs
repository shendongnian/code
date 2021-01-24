    int minGuess = 0;
    int maxGuess = 1000000;
    Random random = new Random();
    int selectedNumber = random.Next(minGuess, maxGuess);
    Console.WriteLine($"Selected number: {selectedNumber}");
            
    int guess;
    int count = 0;
    do
    {
        count++;
        guess = (minGuess + maxGuess) / 2;
        Console.WriteLine($"Guess: {guess}");
        if (selectedNumber < guess)
            maxGuess = guess - 1;
        else
            minGuess = guess + 1;
    } while (guess != selectedNumber);
    Console.WriteLine($"Guessed it in {count} tries");
    Console.ReadLine();
