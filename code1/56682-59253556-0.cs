    string numberText = "";
    try
    {
        Console.Write("Enter an integer: ");
        numberText = Console.ReadLine();
        var result = int.Parse(numberText);
    
        Console.WriteLine("You entered {0}", result);
    }
    catch (FormatException)
    {
        if (numberText.ToLowerInvariant() == "nothing")
        {
            Console.WriteLine("Please, please don't be lazy and enter a valid number next time.");
        }
        else
        {
            throw;
        }
    }    
    finally
    {
        Console.WriteLine("Freed some resources.");
    }
    Console.ReadKey();
