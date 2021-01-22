        try
        {
            goto ILikeCheese;
        }
        finally
        {
            throw new InvalidOperationException("You only have cottage cheese.");
        }
    ILikeCheese:
        Console.WriteLine("MMM. Cheese is yummy.");
