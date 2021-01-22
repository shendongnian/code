        bool jumping = false;
        try
        {
            if (DateTime.Now < DateTime.MaxValue)
            {
                jumping = (Environment.NewLine != "\t");
                goto ILikeCheese;
            }
            return;
        }
        finally
        {
            if (jumping)
                throw new InvalidOperationException("You only have cottage cheese.");
        }
    ILikeCheese:
        Console.WriteLine("MMM. Cheese is yummy.");
