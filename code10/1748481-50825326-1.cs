    if (char.IsDigit(theRealChar))
    {
        Console.WriteLine("Digit");
    }
    // Only check this if the first condition isn't met
    else if (char.IsLetter(theRealChar))
    {
        Console.WriteLine("Letter");
    }
    // Only execute this at all if neither of the above conditions is met
    else
    {
        Console.WriteLine("Not a digit and not a letter");
    }
